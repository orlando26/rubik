#include<SoftwareSerial.h>
SoftwareSerial bt(10, 11);
char movimiento;
void setup(){
    Serial.begin(9600);
    bt.begin(9600);
}

void loop(){
    if(bt.available() > 0){
        movimiento = bt.read();
        Serial.print("Movimeinto: ");
        Serial.println(movimiento);
    }
}