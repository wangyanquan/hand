#ifndef __AD_H_
#define __AD_H_

bit ISendByte(unsigned char sla,unsigned char c);          //厂家自带的与AD模块通信时的发送函数
unsigned char IRcvByte(unsigned char sla);                 //厂家自带的与AD模块通信时的接收函数

bit ISendByte_2(unsigned char sla,unsigned char c);        //厂家自带的与AD模块通信时的发送函数
unsigned char IRcvByte_2(unsigned char sla);               //厂家自带的与AD模块通信时的接收函数
	
#endif