/**
 * Cosas que hizo Lucero 
 */
var a='a',A='A', b='b',B='B', c='c',C='C', d='d',D='D', e='e', E='E', f='f', F='F', g='g', G='G', h='h', H='H', i='i', I='I', j='j', J='J', k='k', K='K', l='l', L='L',  m='m', M='M', n='n', N='N', o='o', O='O', p='p', P='P', q='q', Q='Q', r='r', R='R', s='s', S='S', t='t', T='T', u='u', U='U',v='v',V='V',w='w',W='W', x='x', X='X';
var pieza = A;
var buf1 = "white"; //El color del buffer siempre sera blanco
var buf2 = "green"; //El color de la pareja1 del buffer siempre sera verde
var buf3 = "red";   //El color de la pareja2 del buffer siempre sera rojo
var revisados = []; //Lista de piezas revisadas
var haciaColor;
var pareja1;
var pareja2;
var haciaColor;
var haciaColor3;

$(function(){
   $('#girarTest').click(function(){
       pasoColorBuffer();
        
    });
});

function pasoColorBuffer(){
    haciaColor = hacia(pieza);
    pareja1 = perteneciente(pieza)[0]
    pareja2 = perteneciente(pieza)[1]
    
    haciaColor2 = hacia(pareja1);
    haciaColor3 = hacia(pareja2);
    
    console.log(haciaColor);
    console.log(haciaColor2);   
    console.log(haciaColor3);
    
    revisados.push(pieza);      //Se agrega pieza y parejas a la lista de revisados
    revisados.push(pareja1);
    revisados.push(pareja2);  
    
    if((haciaColor == buf1 && haciaColor2 == buf2 && haciaColor3 == buf3)
        || (haciaColor == buf1 && haciaColor2 == buf3 && haciaColor3 == buf2)
        || (haciaColor == buf2 && haciaColor2 == buf1 && haciaColor3 == buf3)
        || (haciaColor == buf2 && haciaColor2 == buf3 && haciaColor3 == buf1)
        || (haciaColor == buf3 && haciaColor2 == buf1 && haciaColor3 == buf2)
        || (haciaColor == buf3 && haciaColor2 == buf2 && haciaColor3 == buf1)){
            pasoRompeCiclo();
        }
}
 