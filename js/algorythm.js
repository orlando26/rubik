/**
 * Cosas que hizo Lucero 
 */
var a = 'a', A = 'A', b = 'b', B = 'B', c = 'c', C = 'C', d = 'd', D = 'D', e = 'e', E = 'E', f = 'f', F = 'F', g = 'g', G = 'G', h = 'h', H = 'H', i = 'i', I = 'I', j = 'j', J = 'J', k = 'k', K = 'K', l = 'l', L = 'L', m = 'm', M = 'M', n = 'n', N = 'N', o = 'o', O = 'O', p = 'p', P = 'P', q = 'q', Q = 'Q', r = 'r', R = 'R', s = 's', S = 'S', t = 't', T = 'T', u = 'u', U = 'U', v = 'v', V = 'V', w = 'w', W = 'W', x = 'x', X = 'X';

var pAristas = false;
var esquinasMemo = [];
var aristasMemo = [];


$(function() {
    $('#btnPruebas').click(function() {
        solucionEsquinas();
        solucionAristas();
        var letrasMemo = [];
        letrasMemo = letrasMemo.concat(esquinasMemo);
        letrasMemo = letrasMemo.concat(aristasMemo);
        console.log('Letras memorizadas: ' + letrasMemo);
        var algsArray = getAlgsByArray(esquinasMemo);
        console.log('Algoritmos : ' + algsArray);
    });
});

/**Funcion para solucionar esquinas */
function solucionEsquinas() {
    var pAristas = false;
    var pieza = A;
    var buf1 = "white"; //El color del buffer siempre sera blanco
    var buf2 = "green"; //El color de la pareja1 del buffer siempre sera verde
    var buf3 = "red";   //El color de la pareja2 del buffer siempre sera rojo
    var revisados = []; //Lista de piezas revisadas
    var haciaColor;
    var pareja1;
    var pareja2;
    var haciaColor2;
    var haciaColor3;
    var posible;
    var flag = false;
    var listaEsquinas = []; //lista de esquinas que faltan por revisar

    pAristas = false;

    /**
     * loop principal. se repetira hasta que no existan piezas en el arreglo
     * de esquinas por revisar
     */
    memoEsquinas: while (true) {
        /**loop que representa cada ciclo de memorizacion*/
        cicloMemo: do {
            /**Bloque buffer, se saltara este bloque cada que el loop
             * de memorizacion tenga condicion verdadera
             */
            buffer: {
                if (flag) {
                    flag = false
                    break buffer;
                }
                haciaColor = hacia(pieza);
                pareja1 = perteneciente(pieza)[0]
                pareja2 = perteneciente(pieza)[1]

                haciaColor2 = hacia(pareja1);
                haciaColor3 = hacia(pareja2);

                revisados.push(pieza);      //Se agrega pieza y parejas a la lista de revisados
                revisados.push(pareja1);
                revisados.push(pareja2);

                if (((haciaColor == buf1 && haciaColor2 == buf2 && haciaColor3 == buf3)
                    || (haciaColor == buf1 && haciaColor2 == buf3 && haciaColor3 == buf2)
                    || (haciaColor == buf2 && haciaColor2 == buf1 && haciaColor3 == buf3)
                    || (haciaColor == buf2 && haciaColor2 == buf3 && haciaColor3 == buf1)
                    || (haciaColor == buf3 && haciaColor2 == buf1 && haciaColor3 == buf2)
                    || (haciaColor == buf3 && haciaColor2 == buf2 && haciaColor3 == buf1))) {
                    break cicloMemo; //rompe ciclo de memorizacion
                }
            }


            /**Checa cada pieza del arreglo posibles hasta encontrar la pieza correcta */
            for (var posible in posibles(haciaColor)) {
                var parejaTemp1 = perteneciente(posibles(haciaColor)[posible])[0];
                var parejaTemp2 = perteneciente(posibles(haciaColor)[posible])[1];
                var haciaColorTemp2 = centro(parejaTemp1);
                var haciaColorTemp3 = centro(parejaTemp2);

                if ((haciaColorTemp2 == haciaColor2 && haciaColorTemp3 == haciaColor3)
                    || (haciaColorTemp2 == haciaColor3 && haciaColorTemp3 == haciaColor2)) {
                    esquinasMemo.push(posibles(haciaColor)[posible]);
                    pieza = posibles(haciaColor)[posible];
                    break; //rompe el for una vez que encontro la pieza
                }
            }

        } while (true);

        listaEsquinas = [A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X];
        for (var pza in revisados) {
            listaEsquinas.remove(revisados[pza]);
        }
        if (listaEsquinas.length == 0) {
            break memoEsquinas; //rompe el loop principal en caso de que el arreglo ya no tenga piezas por revisar
        }
        var rnd = randomInt(0, listaEsquinas.length - 1);
        pieza = listaEsquinas[rnd];
        pareja1 = perteneciente(pieza)[0];
        pareja2 = perteneciente(pieza)[1];
        buf1 = hacia(pieza);
        buf2 = hacia(pareja1);
        buf3 = hacia(pareja2);
        haciaColor = buf1;
        haciaColor2 = buf2;
        haciaColor3 = buf3;

        esquinasMemo.push(pieza);
        revisados.push(pieza);
        revisados.push(pareja1);
        revisados.push(pareja2);
        flag = true;
    }
    var esquinasRepetidas = [];
    for (var i in esquinasMemo) {
        var esquinaRepetida;
        if (esquinasMemo[i] == esquinasMemo[i - 1]) {
            esquinaRepetida = esquinasMemo[i];
            esquinasRepetidas.push(esquinaRepetida);
        }
    }
    for (var i in esquinasRepetidas) {
        esquinasMemo.remove(esquinasRepetidas[i]);
        esquinasMemo.remove(esquinasRepetidas[i]);
    }

    pAristas = true;
}

/**funcion para solucionar aristas */
function solucionAristas() {
    pAristas = true;
    var pieza = a;
    var buf1 = "white"; //El color del buffer siempre sera blanco
    var buf2 = "green"; //El color de la pareja1 del buffer siempre sera verde
    var revisados = []; //Lista de piezas revisadas
    var haciaColor;
    var pareja1;
    var haciaColor2;
    var posible;
    var flag = false;
    var listaAristas = []; //lista de aristas que faltan por revisar

    pAristas = true;

    /**
     * loop principal. se repetira hasta que no existan piezas en el arreglo
     * de aristas por revisar
     */
    memoAristas: while (true) {
        /**loop que representa cada ciclo de memorizacion*/
        cicloMemoA: do {
            /**Bloque buffer, se saltara este bloque cada que el loop
             * de memorizacion tenga condicion verdadera
             */
            bufferA: {
                if (flag) {
                    flag = false
                    break bufferA;
                }
                haciaColor = hacia(pieza);
                pareja1 = perteneciente(pieza);
                haciaColor2 = hacia(pareja1);

                revisados.push(pieza);      //Se agrega pieza y pareja a la lista de revisados
                revisados.push(pareja1);

                if ((haciaColor == buf1 && haciaColor2 == buf2)
                    || (haciaColor == buf2 && haciaColor2 == buf1)) {
                    break cicloMemoA; //rompe ciclo de memorizacion
                }
            }


            /**Checa cada pieza del arreglo posibles hasta encontrar la pieza correcta */
            for (var posible in posibles(haciaColor)) {
                var parejaTemp1 = perteneciente(posibles(haciaColor)[posible]);
                var haciaColorTemp2 = centro(parejaTemp1);

                if (haciaColorTemp2 == haciaColor2) {
                    aristasMemo.push(posibles(haciaColor)[posible]);
                    pieza = posibles(haciaColor)[posible];
                    break; //rompe el for una vez que encontro la pieza
                }
            }

        } while (true);

        listaAristas = [a, b, c, d, e, f, g, h, "i", j, k, l, m, n, o, p, q, r, s, t, u, v, w, x];

        for (var pza in revisados) {
            listaAristas.remove(revisados[pza]); //Mmmmm aunque se revisaron todas, el arreglo queda en length 1.
        }
        if (listaAristas.length == 0) {
            break memoAristas; //rompe el loop principal en caso de que el arreglo ya no tenga piezas por revisar
        }
        var rnd = randomInt(0, listaAristas.length - 1);
        pieza = listaAristas[rnd];
        pareja1 = perteneciente(pieza);
        buf1 = hacia(pieza);
        buf2 = hacia(pareja1);
        haciaColor = buf1;
        haciaColor2 = buf2;

        aristasMemo.push(pieza);
        revisados.push(pieza);
        revisados.push(pareja1);
        flag = true;
    }
    var aristasRepetidas = [];
    for (var i in aristasMemo) {
        var aristaRepetida;
        if (aristasMemo[i] == aristasMemo[i - 1]) {
            aristaRepetida = aristasMemo[i];
            aristasRepetidas.push(aristaRepetida);
        }
    }
    for (var i in aristasRepetidas) {
        aristasMemo.remove(aristasRepetidas[i]);
        aristasMemo.remove(aristasRepetidas[i]);
    }
}


