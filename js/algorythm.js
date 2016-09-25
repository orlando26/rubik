/**
 * Cosas que hizo Lucero 
 */

/* Funcion que regresa la letra perteneciente a la misma pieza */
function belonging(letter){
    var belonging;
    switch(letter){
        case 'a':belonging = 'm';break;
        case 'b':belonging = 'i';break;
        case 'c':belonging = 'e';break;
        case 'd':belonging = 'q';break;
        case 'e':belonging = 'c';break;
        case 'f':belonging = 'l';break;
        case 'g':belonging = 'w';break;
        case 'h':belonging = 'r';break;
        case 'i':belonging = 'b';break;
        case 'j':belonging = 'p';break;
        case 'k':belonging = 'x';break;
        case 'l':belonging = 'f';break;
        case 'm':belonging = 'a';break;
        case 'n':belonging = 't';break;
        case 'o':belonging = 'u';break;
        case 'p':belonging = 'j';break;
        case 'q':belonging = 'd';break;
        case 'r':belonging = 'h';break;
        case 's':belonging = 'v';break;
        case 't':belonging = 'n';break;
        case 'u':belonging = 'o';break;
        case 'v':belonging = 's';break;
        case 'w':belonging = 'g';break;
        case 'x':belonging = 'k';break;
    }
    return belonging;
}