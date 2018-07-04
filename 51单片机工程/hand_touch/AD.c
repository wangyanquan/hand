#include "ad.h"
#include "i2c.h"

extern bit ack; 

bit ISendByte(unsigned char sla,unsigned char c)              //�����Դ�����ADģ��ͨ��ʱ�ķ��ͺ���
{
   Start_I2c();              //��������
   SendByte(sla);            //����������ַ
   if(ack==0)return(0);
   SendByte(c);              //��������
   if(ack==0)return(0);
   Stop_I2c();               //��������
   return(1);
}

unsigned char IRcvByte(unsigned char sla)                    //�����Դ�����ADģ��ͨ��ʱ�Ľ��պ���
{  unsigned char c;

   Start_I2c();          //��������
   SendByte(sla+1);      //����������ַ
   if(ack==0)return(0);
   c=RcvByte();          //��ȡ����0

   Ack_I2c(1);           //���ͷǾʹ�λ
   Stop_I2c();           //��������
   return(c);
}


/*-----------2*/


bit ISendByte_2(unsigned char sla,unsigned char c)           //�����Դ�����ADģ��ͨ��ʱ�ķ��ͺ���
{
   Start_I2c_2();              //��������
   SendByte_2(sla);            //����������ַ
   if(ack_2==0)return(0);
   SendByte_2(c);              //��������
   if(ack_2==0)return(0);
   Stop_I2c_2();               //��������
   return(1);
}

unsigned char IRcvByte_2(unsigned char sla)                //�����Դ�����ADģ��ͨ��ʱ�Ľ��պ���
{  unsigned char c;

   Start_I2c_2();          //��������
   SendByte_2(sla+1);      //����������ַ
   if(ack_2==0)return(0);
   c=RcvByte_2();          //��ȡ����0

   Ack_I2c_2(1);           //���ͷǾʹ�λ
   Stop_I2c_2();           //��������
   return(c);
}

