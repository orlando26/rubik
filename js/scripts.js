var yellow = "rgb(255, 255, 0)";
var red = "rgb(255, 0, 0)";
var green = "rgb(0, 255, 0)";
var blue = "rgb(0, 0, 255)";
var white = "rgb(255, 255, 255)";
var orange = "rgb(255, 165, 0)";
var cube;
var a='a',A='A', b='b',B='B', c='c',C='C', d='d',D='D', e='e', E='E', f='f', F='F', g='g', G='G', h='h', H='H', i='i', I='I', j='j', J='J', k='k', K='K', l='l', L='L',  m='m', M='M', n='n', N='N', o='o', O='O', p='p', P='P', q='q', Q='Q', r='r', R='R', s='s', S='S', t='t', T='T', u='u', U='U',v='v',V='V',w='w',W='W', x='x', X='X';
var s0=M, s1=p, s2=P, s3=m,s4='CF', s5=o, s6=N, s7=n, s8=O;
var face = 'front';
$(function() {
    init();
    $('.square').click(function() {
        if ($(this).attr('id') != 's4') {
            var currentColor = $(this).css('background-color');
            currentColor = currentColor.toString();
            if (currentColor == blue) {
                $(this).css('background-color', green);
            } else if (currentColor == green) {
                $(this).css('background-color', red);
            } else if (currentColor == red) {
                $(this).css('background-color', orange);
            } else if (currentColor == orange) {
                $(this).css('background-color', yellow);
            } else if (currentColor == yellow) {
                $(this).css('background-color', white);
            } else if (currentColor == white) {
                $(this).css('background-color', blue);
            }
        }
    });
    
     $( ".color-picker" ).draggable({ opacity: 0.7, helper: "clone" });
     
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

function touchHandler(event) {
    var touch = event.changedTouches[0];

    var simulatedEvent = document.createEvent("MouseEvent");
        simulatedEvent.initMouseEvent({
        touchstart: "mousedown",
        touchmove: "mousemove",
        touchend: "mouseup"
    }[event.type], true, true, window, 1,
        touch.screenX, touch.screenY,
        touch.clientX, touch.clientY, false,
        false, false, false, 0, null);

    touch.target.dispatchEvent(simulatedEvent);
    event.preventDefault();
}

function init() {
    document.addEventListener("touchstart", touchHandler, true);
    document.addEventListener("touchmove", touchHandler, true);
    document.addEventListener("touchend", touchHandler, true);
    document.addEventListener("touchcancel", touchHandler, true);
}

function getColorOf(letter){
    var color;
    var letterCode = letter.charCodeAt(0);
    var currentFace = '';
    if(letterCode >=97 && letterCode <= 100){
        currentFace = 'up';
    }else if(letterCode <= 104){
        currentFace = 'back';
    }else if(letterCode <= 108){
        currentFace = 'left';
    }else if(letterCode <= 112){
        currentFace = 'front';
    }else if (letterCode <= 116){
        currentFace = 'right';
    }else if (letterCode <= 120){
        currentFace = 'down';
    }
    
    color = FACES[currentFace][letter];
    return color;
}



