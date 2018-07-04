#include<reg52.h>                      //��Ƭ���Դ�ͷ�ļ�
#include"usart.h"                    //����ͨ��ͷ�ļ�����������ͨ��
#include"AD.h"                      //ģ������ת���ļ���������ADģ���ͨ��
#include<stdio.h>                //c�����Դ��ļ�
#include<stdlib.h>               //C�����Դ��ļ�
#include"delay.h"                //��ʱ�����ļ�

char re[11];                //����������Ϣ������
unsigned char se[5];       //����ADģ�����ݵ��ַ�������
char send[12]={'a','0','0','0','0','0','0','0','0','\r','\n','\0'}; //��Ҫ���͸�����������
int i=0;
int j=0;
int k=0;
#define  PCF8591 0x90     //ADģ���Դ���������

sbit zhi0=P0^0;          //��Ĵָ��ģ��
sbit zhi1=P0^1;          //ʳָ��ģ��
sbit zhi2=P0^2;          //��ָ��ģ��
sbit zhi3=P0^3;           //����ָ��ģ��
sbit zhi4=P0^4;          //СĴָ��ģ��
void main()
{
	usartInit();        //����ͨ�ų�ʼ������
	se[0]='0';          //��������ģ�����ݵ��ַ�������
	se[1]='0';          //��������ģ�����ݵ��ַ�������
	se[2]='0';          //��������ģ�����ݵ��ַ�������
	se[3]='0';          //��������ģ�����ݵ��ַ�������
	se[4]='0';          //��������ģ�����ݵ��ַ�������
	while(1)
	{
		if(re[0]=='1')    //�����Ĵָ���յ�����Ϣ��������ģ��
			zhi0=1;
		else
			zhi0=0;
		
		if(re[1]=='1')  //���ʳָ���յ�����Ϣ��������ģ��
			zhi1=1;
		else
			zhi1=0;
		
		if(re[2]=='1')   //�����ָ���յ�����Ϣ��������ģ��
			zhi2=1;
		else
			zhi2=0;
		
		if(re[3]=='1')    //�������ָ���յ�����Ϣ��������ģ��
			zhi3=1;
		else
			zhi3=0;
		
		if(re[4]=='1')    //���СĴָ���յ�����Ϣ��������ģ��
			zhi4=1;
		else
			zhi4=0;
		delay(300);     //��ʱһ��ʱ��
		ISendByte(PCF8591,0x41);     //��ADģ�鷢����ȡ�������֮���������
		se[0]=IRcvByte(PCF8591);	 //����ADģ�鴫��������
		send[0]='a';                 //�����Ǵ�Ĵָ����
				for(k=0;k<8;k++)    //�����յ�������ת��Ϊ01���У��Ա㷢�͸�����
			{
				if(se[0]&1<<k)
					send[8-k]='1';
				else
					send[8-k]='0';
			}
			usartsend(send);         //ͨ�����ڷ�������

		
		ISendByte(PCF8591,0x42);    //��ȡʳָ���ݲ�����
		se[1]=IRcvByte(PCF8591);		
		send[0]='b';
				for(k=0;k<8;k++)
			{
				if(se[1]&1<<k)
					send[8-k]='1';
				else
					send[8-k]='0';
			}
			usartsend(send);
			
		ISendByte(PCF8591,0x43);    //��ȡ��ָ���ݲ�����
		se[2]=IRcvByte(PCF8591);		
		send[0]='c';
				for(k=0;k<8;k++)
			{
				if(se[2]&1<<k)
					send[8-k]='1';
				else
					send[8-k]='0';
			}
			usartsend(send);
			
		ISendByte(PCF8591,0x40);      //��ȡ����ָ���ݲ�����
		se[3]=IRcvByte(PCF8591);		
		send[0]='d';
				for(k=0;k<8;k++)
			{
				if(se[3]&1<<k)
					send[8-k]='1';
				else
					send[8-k]='0';
			}
			usartsend(send);
			
		ISendByte_2(PCF8591,0x43);       //��ȡСĴָ���ݲ�����
		se[4]=IRcvByte_2(PCF8591);
		send[0]='e';
				for(k=0;k<8;k++)
			{
				if(se[4]&1<<k)
					send[8-k]='1';
				else
					send[8-k]='0';
			}
			usartsend(send);
		
		
		
//		for(j=0;j<5;j++)
//		{ 
//			if(j==0)
//			send[0]='a';
//			else if(j==1)
//			send[0]='b';
//			else if(j==2)
//			send[0]='c';
//			else if(j==3)
//			send[0]='d';
//			else if(j==4)
//			send[0]='e';		
//			 
//			for(k=0;k<8;k++)
//			{
//				if(se[j]&1<<k)
//					send[8-k]='1';
//				else
//					send[8-k]='0';
//			}
//			delay(28);
//			usartsend(send);
//		}
	}
}
void receive() interrupt 4         //��Ƭ���жϺ������������յ����������͹���������
{
	if(RI==1)
	{
		RI=0;
		if(SBUF!='\n')
			{
				re[i]=SBUF;
				i++;
			}
		else
		{
			re[i]='\0';
			i=0;
		}
	}
}
