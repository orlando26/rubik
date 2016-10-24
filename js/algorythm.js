/**
 * Cosas que hizo Lucero 
 */
var a = 'a', A = 'A', b = 'b', B = 'B', c = 'c', C = 'C', d = 'd', D = 'D', e = 'e', E = 'E', f = 'f', F = 'F', g = 'g', G = 'G', h = 'h', H = 'H', i = 'i', I = 'I', j = 'j', J = 'J', k = 'k', K = 'K', l = 'l', L = 'L', m = 'm', M = 'M', n = 'n', N = 'N', o = 'o', O = 'O', p = 'p', P = 'P', q = 'q', Q = 'Q', r = 'r', R = 'R', s = 's', S = 'S', t = 't', T = 'T', u = 'u', U = 'U', v = 'v', V = 'V', w = 'w', W = 'W', x = 'x', X = 'X';



$(function() {
    $('#btnPruebas').click(function() {
        pasoEsquinas();

    });
});

function pasoEsquinas() {
    var pieza = A;
    var buf1 = "white"; //El color del buffer siempre sera blanco
    var buf2 = "green"; //El color de la pareja1 del buffer siempre sera verde
    var buf3 = "red";   //El color de la pareja2 del buffer siempre sera rojo
    var esquinasMemo = []; //lista de esquinas memorizadas
    var revisados = []; //Lista de piezas revisadas
    var haciaColor;
    var pareja1;
    var pareja2;
    var haciaColor;
    var haciaColor3;
    var posible;
    var flag = false;
    var listaEsquinas = []; //lista de esquinas que faltan por revisar

    /**
     * loop principal. se repetira hasta que no existan piezas en el arreglo
     * de esquinas por revisar
     */
    memoEsquinas: while (true) {
        /**loop que representa cada ciclo de memorizacion*/
        do {
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
                    console.log('encontro ' + pieza + ' :D');
                    break; //rompe el for una vez que encontro la pieza
                }
            }

        } while (!((haciaColor == buf1 && haciaColor2 == buf2 && haciaColor3 == buf3)
            || (haciaColor == buf1 && haciaColor2 == buf3 && haciaColor3 == buf2)
            || (haciaColor == buf2 && haciaColor2 == buf1 && haciaColor3 == buf3)
            || (haciaColor == buf2 && haciaColor2 == buf3 && haciaColor3 == buf1)
            || (haciaColor == buf3 && haciaColor2 == buf1 && haciaColor3 == buf2)
            || (haciaColor == buf3 && haciaColor2 == buf2 && haciaColor3 == buf1)));
            
        listaEsquinas = [A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X];
        for (var pza in revisados) {
            listaEsquinas.remove(revisados[pza]);
        }
        if (listaEsquinas.length == 0) {
            console.log('se acabo :D')
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
    console.log(esquinasMemo);
}


