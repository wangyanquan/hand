#include<reg52.h>                      //单片机自带头文件
#include"usart.h"                    //串口通信头文件，用于蓝牙通信
#include"AD.h"                      //模拟数字转化文件，用于与AD模块的通信
#include<stdio.h>                //c语言自带文件
#include<stdlib.h>               //C语言自带文件
#include"delay.h"                //延时函数文件

char re[11];                //接收蓝牙信息的数组
unsigned char se[5];       //接收AD模块数据的字符串数组
char send[12]={'a','0','0','0','0','0','0','0','0','\r','\n','\0'}; //需要发送给蓝牙的数组
int i=0;
int j=0;
int k=0;
#define  PCF8591 0x90     //AD模块自带的器件号

sbit zhi0=P0^0;          //大拇指震动模块
sbit zhi1=P0^1;          //食指震动模块
sbit zhi2=P0^2;          //中指震动模块
sbit zhi3=P0^3;           //无名指震动模块
sbit zhi4=P0^4;          //小拇指震动模块
void main()
{
	usartInit();        //串口通信初始化函数
	se[0]='0';          //接收蓝牙模块数据的字符串数组
	se[1]='0';          //接收蓝牙模块数据的字符串数组
	se[2]='0';          //接收蓝牙模块数据的字符串数组
	se[3]='0';          //接收蓝牙模块数据的字符串数组
	se[4]='0';          //接收蓝牙模块数据的字符串数组
	while(1)
	{
		if(re[0]=='1')    //如果大拇指接收到震动信息，启动震动模块
			zhi0=1;
		else
			zhi0=0;
		
		if(re[1]=='1')  //如果食指接收到震动信息，启动震动模块
			zhi1=1;
		else
			zhi1=0;
		
		if(re[2]=='1')   //如果中指接收到震动信息，启动震动模块
			zhi2=1;
		else
			zhi2=0;
		
		if(re[3]=='1')    //如果无名指接收到震动信息，启动震动模块
			zhi3=1;
		else
			zhi3=0;
		
		if(re[4]=='1')    //如果小拇指接收到震动信息，启动震动模块
			zhi4=1;
		else
			zhi4=0;
		delay(300);     //延时一段时间
		ISendByte(PCF8591,0x41);     //给AD模块发送提取数据命令，之后接收数据
		se[0]=IRcvByte(PCF8591);	 //接收AD模块传来的数据
		send[0]='a';                 //表明是大拇指数据
				for(k=0;k<8;k++)    //将接收到的数据转化为01序列，以便发送给蓝牙
			{
				if(se[0]&1<<k)
					send[8-k]='1';
				else
					send[8-k]='0';
			}
			usartsend(send);         //通过串口发送数据

		
		ISendByte(PCF8591,0x42);    //提取食指数据并发送
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
			
		ISendByte(PCF8591,0x43);    //提取中指数据并发送
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
			
		ISendByte(PCF8591,0x40);      //提取无名指数据并发送
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
			
		ISendByte_2(PCF8591,0x43);       //提取小拇指数据并发送
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
void receive() interrupt 4         //单片机中断函数，用来接收电脑蓝牙发送过来的数据
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
