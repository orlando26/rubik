var yellow = "rgb(255, 255, 0)";
var red = "rgb(255, 0, 0)";
var green = "rgb(0, 255, 0)";
var blue = "rgb(0, 0, 255)";
var white = "rgb(255, 255, 255)";
var orange = "rgb(255, 165, 0)";
var cube;
var colorPicker;
var a='a',A='A', b='b',B='B', c='c',C='C', d='d',D='D', e='e', E='E', f='f', F='F', g='g', G='G', h='h', H='H', i='i', I='I', j='j', J='J', k='k', K='K', l='l', L='L',  m='m', M='M', n='n', N='N', o='o', O='O', p='p', P='P', q='q', Q='Q', r='r', R='R', s='s', S='S', t='t', T='T', u='u', U='U',v='v',V='V',w='w',W='W', x='x', X='X';
var s0=M, s1=p, s2=P, s3=m,s4='CF', s5=o, s6=N, s7=n, s8=O;
var face = 'front';
$(function() {
    //init();
    $('#btnPruebas').click(
        function(){
            var p = perteneciente('a');
            var colorCentro = centro('A'); 
            console.log(hacia('N'));
            });
    
    $('.square').click(function() {
        if ($(this).attr('id') != 's4') {
            
            $(this).css('background-color', colorPicker);
        }
    });
    
     $( ".color-picker" ).draggable(
         { opacity: 0.7, helper: "clone" }
         ).click(function(){
             colorPicker = $(this).css('background-color');
         });
     
     $('.square').droppable({
         drop: function(event, ui){
             event.preventDefault();
            if ($(this).attr('class') != 'square center ui-droppable'){
                $(this).css('background-color', $(ui.draggable).css('background-color'));
            }  
         }
     });
    
    $('#girarTest').click(function(){
        console.log(getColorOf(a));
        var simpleFormMoves = [
            "R'", "D'", "R", "D"
        ];
        
        var movements = makeMovementsArray(simpleFormMoves);
        cube._solve(movements);
    });

    $('#statebtn').click(function() {
        if(typeof Android != "undefined"){
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
            s0=Q;s1=t;s2=T;s3=q;s4='CR';s5=s;s6=R;s7=r;s8=S;
        } else if (face == 'right') {
            face = 'left';
            $('#face-name').text("Left Face")
            $('.square').css('background-color', orange);
            s0=I;s1=l;s2=L;s3=i;s4='CL';s5=k;s6=J;s7=j;s8=K;
        } else if (face == 'left') {
            face = 'up';
            $('#face-name').text("Up Face")
            $('.square').css('background-color', white);
            s0=C;s1=b;s2=B;s3=c;s4='CU';s5=a;s6=D;s7=d;s8=A;
        } else if (face == 'up') {
            face = 'down';
            $('#face-name').text("Bottom Face")
            $('.square').css('background-color', yellow);
            s0=U;s1=x;s2=X;s3=u;s4='CD';s5=w;s6=V;s7=v;s8=W;
        } else if (face == 'down') {
            face = 'back';
            $('#face-name').text("Back Face")
            $(this).text('save state');
            $('.square').css('background-color', blue);
            s0=E;s1=h;s2=H;s3=e;s4='CB';s5=g;s6=F;s7=f;s8=G;
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

function getMovement(move){
    var movement;
    switch(move){
        case "U":
           movement = {face: "U",slice: "E",rotate: "left"};
           break;
        case "U'":
           movement = {face: "U",slice: "E",rotate: "right"};
           break;
        case "D":
           movement = {face: "D",slice: "E",rotate: "right"};
           break;
        case "D'":
           movement = {face: "D",slice: "E",rotate: "left"};
           break;
        case "R":
           movement = {face: "R",slice: "M",rotate: "left"};
           break;
        case "R'":
           movement = {face: "R",slice: "M",rotate: "right"};
           break;
        case "L":
           movement = {face: "L",slice: "M",rotate: "Right"};
           break;
        case "L'":
           movement = {face: "L",slice: "M",rotate: "left"};
           break;
        case "F":
           movement = {face: "F",slice: "S",rotate: "right"};
           break;
        case "F'":
           movement = {face: "F",slice: "S",rotate: "left"};
           break;
        case "B":
           movement = {face: "B",slice: "S",rotate: "left"};
           break;
        case "B'":
           movement = {face: "B",slice: "S",rotate: "right"};
           break;
    }
    return movement;
}

function makeMovementsArray(array){
    var movementsArray = [];
    array.forEach(function(element){
       var move = getMovement(element);
       movementsArray.push(move); 
    });
    return movementsArray;
}

function hacia(letter){
    var color;
    var letterCode = letter.charCodeAt(0);
    var currentFace = obtenerCara(letterCode);
    color = FACES[currentFace][letter];
    return color;
}

function centro(pieza){
       var letterCode = pieza.charCodeAt(0);
       var cara = obtenerCara(letterCode);
       var colorCentro = "";
       var colores = [];
       for (var key in FACES[cara]){
           colores.push(FACES[cara][key]);
       }
       colorCentro = colores[3]
       return colorCentro;
}

function obtenerCara(letterCode){
    var currentFace = '';
    if((letterCode >=97 && letterCode <= 100) | (letterCode >=65 && letterCode <= 68)){
        currentFace = 'up';
    }else if((letterCode >= 101 && letterCode <= 104) | (letterCode >=69 && letterCode <= 72)){
        currentFace = 'back';
    }else if((letterCode >= 105 && letterCode <= 108) | (letterCode >=73 && letterCode <= 76)){
        currentFace = 'left';
    }else if((letterCode >= 109 && letterCode <= 112) | (letterCode >=77 && letterCode <= 80)){
        currentFace = 'front';
    }else if ((letterCode >= 113 && letterCode <= 116) | (letterCode >=81 && letterCode <= 84)){
        currentFace = 'right';
    }else if ((letterCode >= 117 && letterCode <= 120) | (letterCode >=85 && letterCode <= 88)){
        currentFace = 'down';
    }
    return currentFace;
}

/* Funcion que regresa la letra perteneciente a la misma pieza */
function perteneciente(letter){
    var perteneciente;
    switch(letter){
        case 'a':perteneciente = 'm';break;
        case 'b':perteneciente = 'i';break;
        case 'c':perteneciente = 'e';break;
        case 'd':perteneciente = 'q';break;
        case 'e':perteneciente = 'c';break;
        case 'f':perteneciente = 'l';break;
        case 'g':perteneciente = 'w';break;
        case 'h':perteneciente = 'r';break;
        case 'i':perteneciente = 'b';break;
        case 'j':perteneciente = 'p';break;
        case 'k':perteneciente = 'x';break;
        case 'l':perteneciente = 'f';break;
        case 'm':perteneciente = 'a';break;
        case 'n':perteneciente = 't';break;
        case 'o':perteneciente = 'u';break;
        case 'p':perteneciente = 'j';break;
        case 'q':perteneciente = 'd';break;
        case 'r':perteneciente = 'h';break;
        case 's':perteneciente = 'v';break;
        case 't':perteneciente = 'n';break;
        case 'u':perteneciente = 'o';break;
        case 'v':perteneciente = 's';break;
        case 'w':perteneciente = 'g';break;
        case 'x':perteneciente = 'k';break;
        
        case 'A':perteneciente = ['N', 'Q'];break;
        case 'B':perteneciente = ['J', 'M'];break;
        case 'C':perteneciente = ['F', 'I'];break;
        case 'D':perteneciente = ['R', 'E'];break;
        case 'E':perteneciente = ['R', 'D'];break;
        case 'F':perteneciente = ['C', 'I'];break;
        case 'G':perteneciente = ['L', 'X'];break;
        case 'H':perteneciente = ['W', 'S'];break;
        case 'I':perteneciente = ['F', 'C'];break;
        case 'J':perteneciente = ['B', 'M'];break;
        case 'K':perteneciente = ['P', 'U'];break;
        case 'L':perteneciente = ['X', 'G'];break;
        case 'M':perteneciente = ['J', 'B'];break;
        case 'N':perteneciente = ['A', 'Q'];break;
        case 'O':perteneciente = ['T', 'V'];break;
        case 'P':perteneciente = ['U', 'K'];break;
        case 'Q':perteneciente = ['N', 'A'];break;
        case 'R':perteneciente = ['D', 'E'];break;
        case 'S':perteneciente = ['H', 'W'];break;
        case 'T':perteneciente = ['V', 'O'];break;
        case 'U':perteneciente = ['K', 'P'];break;
        case 'V':perteneciente = ['O', 'T'];break;
        case 'W':perteneciente = ['S', 'H'];break;
        case 'X':perteneciente = ['G', 'L'];break;
        
    }
    return perteneciente;
}




