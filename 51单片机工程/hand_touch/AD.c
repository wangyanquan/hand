#include "ad.h"
#include "i2c.h"

extern bit ack; 

bit ISendByte(unsigned char sla,unsigned char c)              //厂家自带的与AD模块通信时的发送函数
{
   Start_I2c();              //启动总线
   SendByte(sla);            //发送器件地址
   if(ack==0)return(0);
   SendByte(c);              //发送数据
   if(ack==0)return(0);
   Stop_I2c();               //结束总线
   return(1);
}

unsigned char IRcvByte(unsigned char sla)                    //厂家自带的与AD模块通信时的接收函数
{  unsigned char c;

   Start_I2c();          //启动总线
   SendByte(sla+1);      //发送器件地址
   if(ack==0)return(0);
   c=RcvByte();          //读取数据0

   Ack_I2c(1);           //发送非就答位
   Stop_I2c();           //结束总线
   return(c);
}


/*-----------2*/


bit ISendByte_2(unsigned char sla,unsigned char c)           //厂家自带的与AD模块通信时的发送函数
{
   Start_I2c_2();              //启动总线
   SendByte_2(sla);            //发送器件地址
   if(ack_2==0)return(0);
   SendByte_2(c);              //发送数据
   if(ack_2==0)return(0);
   Stop_I2c_2();               //结束总线
   return(1);
}

unsigned char IRcvByte_2(unsigned char sla)                //厂家自带的与AD模块通信时的接收函数
{  unsigned char c;

   Start_I2c_2();          //启动总线
   SendByte_2(sla+1);      //发送器件地址
   if(ack_2==0)return(0);
   c=RcvByte_2();          //读取数据0

   Ack_I2c_2(1);           //发送非就答位
   Stop_I2c_2();           //结束总线
   return(c);
}

