#include"usart.h"                     //����ͨ�ź���
void usartInit()                      //���ڳ�ʼ������
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
void usartsend(unsigned char* Data)    //���ڷ��ͺ���
{
	while(*Data!='\0')
	{
		SBUF=*Data;
		while(!TI);
		TI=0;
		Data++;
	}
}