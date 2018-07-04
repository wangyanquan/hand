#include"usart.h"                     //串口通信函数
void usartInit()                      //串口初始化函数
{	
	SCON=0x50;
	TMOD=0x20;
	PCON=0x00;
	TH1=0xFD;
	TL1=0xFD;
	TR1=1;	
	ES=1;
	EA=1;
}
void usartsend(unsigned char* Data)    //串口发送函数
{
	while(*Data!='\0')
	{
		SBUF=*Data;
		while(!TI);
		TI=0;
		Data++;
	}
}