#include<SoftwareSerial.h>
SoftwareSerial bt(10, 11);
int R[2] = {2, 3};
int L[2] = {4, 5};
int F[2] = {6, 7};
int B[2] = {8, 9};
int U[2] = {12, 13};
int tiempo = 330;
char movimiento;
void setup(){
    Serial.begin(9600);
    bt.begin(9600);
    for(int i = 2;i<= 13; i++){
      if(i != 10 && i != 11)pinMode(i, OUTPUT);
    }
}

void loop(){
    if(bt.available() > 0){
        movimiento = bt.read();
        Serial.print("Movimeinto: ");
        Serial.println(movimiento);
        girar(movimiento);
    }
}

void giroNormal(int motor[2]){
  digitalWrite(motor[0], HIGH);
  digitalWrite(motor[1], LOW);
}
void giroInverso(int motor[2]){
  digitalWrite(motor[0], LOW);
  digitalWrite(motor[1], HIGH);
}
void detener(int motor[2]){
  digitalWrite(motor[0], LOW);
  digitalWrite(motor[1], LOW);
}

void girar(char cara){
  switch(cara){
    case 'F':
      giroNormal(F);
      delay(tiempo);
      detener(F);
      break;
    case 'f':
      giroInverso(F);
      delay(tiempo);
      detener(F);
      break;
    case 'R':
      giroNormal(R);
      delay(tiempo);
      detener(R);
      break;
    case 'r':
      giroInverso(R);
      delay(tiempo);
      detener(R);
      break;  
    case 'L':
      giroNormal(L);
      delay(tiempo);
      detener(L);
      break;
    case 'l':
      giroInverso(L);
      delay(tiempo);
      detener(L);
      break;
    case 'U':
      giroNormal(U);
      delay(tiempo);
      detener(U);
      break;
    case 'u':
      giroInverso(U);
      delay(tiempo);
      detener(U);
      break;  
    case 'B':
      giroNormal(B);
      delay(tiempo);
      detener(B);
      break;
    case 'b':
      giroInverso(B);
      delay(tiempo);
      detener(B);
      break;  
  }
}
