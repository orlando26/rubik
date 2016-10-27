var yellow = "rgb(255, 255, 0)";
var red = "rgb(255, 0, 0)";
var green = "rgb(0, 255, 0)";
var blue = "rgb(0, 0, 255)";
var white = "rgb(255, 255, 255)";
var orange = "rgb(255, 165, 0)";
var cube;
var colorPicker;
var a = 'a', A = 'A', b = 'b', B = 'B', c = 'c', C = 'C', d = 'd', D = 'D', e = 'e', E = 'E', f = 'f', F = 'F', g = 'g', G = 'G', h = 'h', H = 'H', i = 'i', I = 'I', j = 'j', J = 'J', k = 'k', K = 'K', l = 'l', L = 'L', m = 'm', M = 'M', n = 'n', N = 'N', o = 'o', O = 'O', p = 'p', P = 'P', q = 'q', Q = 'Q', r = 'r', R = 'R', s = 's', S = 'S', t = 't', T = 'T', u = 'u', U = 'U', v = 'v', V = 'V', w = 'w', W = 'W', x = 'x', X = 'X';
var s0 = M, s1 = p, s2 = P, s3 = m, s4 = 'CF', s5 = o, s6 = N, s7 = n, s8 = O;
var face = 'front';
var esquinasMemo = true;
var aristasMemo = false;
$(function() {
    //init();


    $('.square').click(function() {
        if ($(this).attr('id') != 's4') {

            $(this).css('background-color', colorPicker);
        }
    });

    $(".color-picker").draggable(
        { opacity: 0.7, helper: "clone" }
    ).click(function() {
        colorPicker = $(this).css('background-color');
    });

    $('.square').droppable({
        drop: function(event, ui) {
            event.preventDefault();
            if ($(this).attr('class') != 'square center ui-droppable') {
                $(this).css('background-color', $(ui.draggable).css('background-color'));
            }
        }
    });

    $('#girarTest').click(function() {
        solucionEsquinas();
        solucionAristas();
        var letrasMemo = [];
        letrasMemo = letrasMemo.concat(esquinasMemo);
        letrasMemo = letrasMemo.concat(aristasMemo);
        console.log('Letras memorizadas: ' + letrasMemo);
        var algsArray = getAlgsByArray(esquinasMemo);
        console.log('Algoritmos : ' + algsArray);

        if (algsArray.length != 0) {
            var movsArr = makeMovementsArray(algsArray);
            cube._solve(movsArr);
        }
    });

    $('#statebtn').click(function() {
        if (typeof Android != "undefined") {
            Android.showToast("hola");
        }
        FACES[face][s0] = getColor($('#s0').css('background-color').toString());
        FACES[face][s1] = getColor($('#s1').css('background-color').toString());
        FACES[face][s2] = getColor($('#s2').css('background-color').toString());
        FACES[face][s3] = getColor($('#s3').css('background-color').toString());
        FACES[face][s4] = getColor($('#s4').css('background-color').toString());
        FACES[face][s5] = getColor($('#s5').css('background-color').toString());
        FACES[face][s6] = getColor($('#s6').css('background-color').toString());
        FACES[face][s7] = getColor($('#s7').css('background-color').toString());
        FACES[face][s8] = getColor($('#s8').css('background-color').toString());

        if (face == 'front') {
            face = 'right';
            $('#face-name').text("Right Face")
            $('.square').css('background-color', red);
            s0 = Q; s1 = t; s2 = T; s3 = q; s4 = 'CR'; s5 = s; s6 = R; s7 = r; s8 = S;
        } else if (face == 'right') {
            face = 'left';
            $('#face-name').text("Left Face")
            $('.square').css('background-color', orange);
            s0 = I; s1 = l; s2 = L; s3 = i; s4 = 'CL'; s5 = k; s6 = J; s7 = j; s8 = K;
        } else if (face == 'left') {
            face = 'up';
            $('#face-name').text("Up Face")
            $('.square').css('background-color', white);
            s0 = C; s1 = b; s2 = B; s3 = c; s4 = 'CU'; s5 = a; s6 = D; s7 = d; s8 = A;
        } else if (face == 'up') {
            face = 'down';
            $('#face-name').text("Bottom Face")
            $('.square').css('background-color', yellow);
            s0 = U; s1 = x; s2 = X; s3 = u; s4 = 'CD'; s5 = w; s6 = V; s7 = v; s8 = W;
        } else if (face == 'down') {
            face = 'back';
            $('#face-name').text("Back Face")
            $(this).text('save state');
            $('.square').css('background-color', blue);
            s0 = E; s1 = h; s2 = H; s3 = e; s4 = 'CB'; s5 = g; s6 = F; s7 = f; s8 = G;
        } else if (face == 'back') {
            $('#rubik-link').show();
            face = '';
            YUI().use('node', 'rubik-simple', function(Y) {
                cube = window.cube = new Y.Rubik();
                cube.run();
            });

        }
    });
});

function getColor(color) {
    var coloString = "";
    if (color == blue) coloString = "blue";
    else if (color == red) coloString = "red";
    else if (color == orange) coloString = "orange";
    else if (color == green) coloString = "green";
    else if (color == yellow) coloString = "yellow";
    else if (color == white) coloString = "white";
    return coloString;
}

function getMovement(move) {
    var movement;
    switch (move) {
        case "U":
            movement = { face: "U", slice: "E", rotate: "left" };
            break;
        case "U'":
            movement = { face: "U", slice: "E", rotate: "right" };
            break;
        case "D":
            movement = { face: "D", slice: "E", rotate: "right" };
            break;
        case "D'":
            movement = { face: "D", slice: "E", rotate: "left" };
            break;
        case "R":
            movement = { face: "R", slice: "M", rotate: "left" };
            break;
        case "R'":
            movement = { face: "R", slice: "M", rotate: "right" };
            break;
        case "L":
            movement = { face: "L", slice: "M", rotate: "Right" };
            break;
        case "L'":
            movement = { face: "L", slice: "M", rotate: "left" };
            break;
        case "F":
            movement = { face: "F", slice: "S", rotate: "right" };
            break;
        case "F'":
            movement = { face: "F", slice: "S", rotate: "left" };
            break;
        case "B":
            movement = { face: "B", slice: "S", rotate: "left" };
            break;
        case "B'":
            movement = { face: "B", slice: "S", rotate: "right" };
            break;
    }
    return movement;
}

function makeMovementsArray(array) {
    var movementsArray = [];
    array.forEach(function(element) {
        var move;
        if (element.indexOf(2) != -1) {
            move = getMovement(element.replace("2", ""));
            movementsArray.push(move);
            movementsArray.push(move);
        } else {
            move = getMovement(element);
            movementsArray.push(move);
        }

    });
    return movementsArray;
}

function hacia(letter) {
    var color;
    var letterCode = letter.charCodeAt(0);
    var currentFace = obtenerCara(letterCode);
    color = FACES[currentFace][letter];
    return color;
}

function centro(pieza) {
    var letterCode = pieza.charCodeAt(0);
    var cara = obtenerCara(letterCode);
    var colorCentro = "";
    var colores = [];
    for (var key in FACES[cara]) {
        colores.push(FACES[cara][key]);
    }
    colorCentro = colores[4]
    return colorCentro;
}

function obtenerCara(letterCode) {
    var currentFace = '';
    if ((letterCode >= 97 && letterCode <= 100) | (letterCode >= 65 && letterCode <= 68)) {
        currentFace = 'up';
    } else if ((letterCode >= 101 && letterCode <= 104) | (letterCode >= 69 && letterCode <= 72)) {
        currentFace = 'back';
    } else if ((letterCode >= 105 && letterCode <= 108) | (letterCode >= 73 && letterCode <= 76)) {
        currentFace = 'left';
    } else if ((letterCode >= 109 && letterCode <= 112) | (letterCode >= 77 && letterCode <= 80)) {
        currentFace = 'front';
    } else if ((letterCode >= 113 && letterCode <= 116) | (letterCode >= 81 && letterCode <= 84)) {
        currentFace = 'right';
    } else if ((letterCode >= 117 && letterCode <= 120) | (letterCode >= 85 && letterCode <= 88)) {
        currentFace = 'down';
    }
    return currentFace;
}

/* Funcion que regresa la letra perteneciente a la misma pieza */
function perteneciente(letter) {
    var perteneciente;
    switch (letter) {
        case 'a': perteneciente = 'm'; break;
        case 'b': perteneciente = 'i'; break;
        case 'c': perteneciente = 'e'; break;
        case 'd': perteneciente = 'q'; break;
        case 'e': perteneciente = 'c'; break;
        case 'f': perteneciente = 'l'; break;
        case 'g': perteneciente = 'w'; break;
        case 'h': perteneciente = 'r'; break;
        case 'i': perteneciente = 'b'; break;
        case 'j': perteneciente = 'p'; break;
        case 'k': perteneciente = 'x'; break;
        case 'l': perteneciente = 'f'; break;
        case 'm': perteneciente = 'a'; break;
        case 'n': perteneciente = 't'; break;
        case 'o': perteneciente = 'u'; break;
        case 'p': perteneciente = 'j'; break;
        case 'q': perteneciente = 'd'; break;
        case 'r': perteneciente = 'h'; break;
        case 's': perteneciente = 'v'; break;
        case 't': perteneciente = 'n'; break;
        case 'u': perteneciente = 'o'; break;
        case 'v': perteneciente = 's'; break;
        case 'w': perteneciente = 'g'; break;
        case 'x': perteneciente = 'k'; break;

        case 'A': perteneciente = ['N', 'Q']; break;
        case 'B': perteneciente = ['J', 'M']; break;
        case 'C': perteneciente = ['F', 'I']; break;
        case 'D': perteneciente = ['R', 'E']; break;
        case 'E': perteneciente = ['R', 'D']; break;
        case 'F': perteneciente = ['C', 'I']; break;
        case 'G': perteneciente = ['L', 'X']; break;
        case 'H': perteneciente = ['W', 'S']; break;
        case 'I': perteneciente = ['F', 'C']; break;
        case 'J': perteneciente = ['B', 'M']; break;
        case 'K': perteneciente = ['P', 'U']; break;
        case 'L': perteneciente = ['X', 'G']; break;
        case 'M': perteneciente = ['J', 'B']; break;
        case 'N': perteneciente = ['A', 'Q']; break;
        case 'O': perteneciente = ['T', 'V']; break;
        case 'P': perteneciente = ['U', 'K']; break;
        case 'Q': perteneciente = ['N', 'A']; break;
        case 'R': perteneciente = ['D', 'E']; break;
        case 'S': perteneciente = ['H', 'W']; break;
        case 'T': perteneciente = ['V', 'O']; break;
        case 'U': perteneciente = ['K', 'P']; break;
        case 'V': perteneciente = ['O', 'T']; break;
        case 'W': perteneciente = ['S', 'H']; break;
        case 'X': perteneciente = ['G', 'L']; break;

    }
    return perteneciente;
}

/* Devuelve las letras posibles
    @param: color
    @return: posibles[] */
function posibles(color) {
    var posibles = [];
    if (pAristas == true) {
        switch (color) {
            case 'white': posibles = [a, b, c, d]; break;
            case 'blue': posibles = [e, f, g, h]; break;
            case 'orange': posibles = [i, j, k, l]; break;
            case 'green': posibles = [m, n, o, p]; break;
            case 'red': posibles = [q, r, s, t]; break;
            case "yellow": posibles = [u, v, w, x]; break;
        }
    } else {
        switch (color) {
            case 'white': posibles = [A, B, C, D]; break;
            case 'blue': posibles = [E, F, G, H]; break;
            case 'orange': posibles = [I, J, K, L]; break;
            case 'green': posibles = [M, N, O, P]; break;
            case 'red': posibles = [Q, R, S, T]; break;
            case 'yellow': posibles = [U, V, W, X]; break;
        }
    }
    return posibles;
}

/**
 * Remove piece from an array 
 * @param {String} value
 */
Array.prototype.remove = function(v) { this.splice(this.indexOf(v) == -1 ? this.length : this.indexOf(v), 1); }

// Returns a random integer between min (included) and max (excluded)
// Using Math.round() will give you a non-uniform distribution!
function randomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function getAlgsByArray(arr) {
    var algs = [];
    for (var i in arr) {
        algs = algs.concat(getAlgsByLetter(arr[i], i % 2));
    }
    return algs;
}

function getAlgsByLetter(letter, type) {
    var algs = [];
    switch (letter) {
        case 'B':
            algs = type != 0 ?
                ["R", "B'", "R", "F2", "R'", "B", "R", "F2", "R2"] : ["R2", "F2", "R'", "B'", "R", "F2", "R'", "B", "R'"];
            break;
        case 'C':
            algs = type != 0 ?
                ["R2", "B2", "R", "F", "R'", "B2", "R", "F'", "R"] : ["R'", "F", "R'", "B2", "R", "F'", "R'", "B2", "R2"];
            break;
        case 'D':
            algs = type != 0 ?
                [] : [];
            break;
        case 'E':
            algs = type != 0 ?
                ["U2", "L", "U2", "R'", "U", "F2", "R'", "F2", "R", "U2", "L'", "U", "R"]
                : ["U2'", "R", "B", "R'", "B2", "L", "U2", "L'", "U2", "B", "R'", "U2", "R"];
            break;
        case 'F':
            algs = type != 0 ?
                ["R'", "L'", "F'", "R", "B2", "R'", "F", "R", "B2", "L"] :
                ["L'", "B2", "R'", "F'", "R", "B2", "R'", "F", "R", "L"];
            break;
        case 'G':
            algs = type != 0 ?
                ["U'", "B'", "R'", "B", "L", "B'", "R", "B", "L'", "U"] :
                ["U'", "L", "B'", "R'", "B", "L'", "B'", "R", "B", "U"];
            break;
        case 'H':
            algs = type != 0 ?
                ["B2", "L", "B'", "R", "B", "L'", "B'", "R'", "B'"] :
                ["B", "R", "B", "L", "B'", "R'", "B", "L'", "B2"];
            break;
        case 'I':
            algs = type != 0 ?
                ["R'", "F'", "R", "B'", "R'", "F", "R", "B"] : ["L", "F'", "L'", "B", "L", "F", "L'", "B'"];
            break;
        case 'J':
            algs = type != 0 ?
                ["F", "R", "B", "R'", "F'", "R", "B'", "R'"] : ["R", "B", "R'", "F", "R", "B'", "R'", "F'"];
            break;
        case 'K':
            algs = type != 0 ?
                ["R", "B'", "R", "F'", "R'", "B", "R", "F", "R2"] : ["R2", "F'", "R'", "B'", "R", "F", "R'", "B", "R'"];
            break;
        case 'L':
            algs = type != 0 ?
                ["R'", "F", "R'", "B", "R", "F'", "R'", "B'", "R2"] : ["R2", "B", "R", "F", "R'", "B'", "R", "F'", "R"];
            break;
        case 'M':
            algs = type != 0 ?
                ["L", "F2", "R", "B", "R'", "F2", "R", "B'", "R'", "L'"] :
                ["R", "L", "B", "R'", "F2", "R", "B'", "R'", "F2", "L'"];
            break;
        case 'N':
            algs = type != 0 ?
                [] : [];
            break;
        case 'O':
            algs = type != 0 ?
                ["F'", "R'", "F'", "L'", "F", "R", "F'", "L", "F2"] : ["F2", "L'", "F", "R'", "F'", "L", "F", "R", "F"];
            break;
        case 'P':
            algs = type != 0 ?
                ["U", "L'", "F", "R", "F'", "L", "F", "R'", "F'", "U'"] : ["U", "F", "R", "F'", "L'", "F", "R'", "F'", "L", "U'"];
            break;
        case 'Q':
            algs = type != 0 ?
                [] : [];
            break;
        case 'R':
            algs = type != 0 ?
                ["U2", "R", "B", "R'", "B2", "L", "U2", "L'", "U2", "B", "R'", "U2", "R"] :
                ["U2", "L", "U2", "R'", "U", "F2", "R'", "F2", "R", "U2", "L'", "U", "R"];
            break;
        case 'S':
            algs = type != 0 ?
                ["R'", "F'", "R", "B", "R'", "F", "R", "B'"] : ["B", "R'", "F'", "R", "B'", "R'", "F", "R"];
            break;
        case 'T':
            algs = type != 0 ?
                ["F'", "R", "B", "R'", "F", "R", "B'", "R'"] : ["R", "B", "R'", "F'", "R", "B'", "R'", "F"];
            break;
        case 'U':
            algs = type != 0 ?
                ["F2", "R", "B", "R'", "F2", "R", "B'", "R'"] : ["R", "B", "R'", "F2", "R", "B'", "R'", "F2"];
            break;
        case 'V':
            algs = type != 0 ?
                ["U2", "L'", "B'", "L", "F2", "L'", "B", "L", "F2", "U2"] :
                ["U2", "F2", "L'", "B'", "L", "F2", "L'", "B", "L", "U2"];
            break;
        case 'W':
            algs = type != 0 ?
                ["U", "F'", "L'", "F", "R2", "F'", "L", "F", "R2", "U'"] :
                ["U", "R2", "U'", "F", "U", "F'", "R2", "F", "U'", "F'"];
            break;
        case 'X':
            algs = type != 0 ?
                ["R'", "F'", "R", "B2", "R'", "F", "R", "B2"] :
                ["B2", "R'", "F'", "R", "B2", "R'", "F", "R"];
            break;
    }
    return algs;
}


