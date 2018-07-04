#ifndef __I2C_H_
#define __I2C_H_
#include<reg52.h>                       //厂家自带的i2c底层通信协议


extern bit ack;
extern bit ack_2;

void Start_I2c();  
void Start_I2c_2();

void Stop_I2c();
void Stop_I2c_2();

void Ack_I2c(bit a);
void Ack_I2c_2(bit a);

void SendByte(unsigned char  c);
void SendByte_2(unsigned char  c);

unsigned char RcvByte();
unsigned char RcvByte_2();
#endif