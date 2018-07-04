using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class Blue : MonoBehaviour
{

    public string Status;                       //显示蓝牙连接状态
    private string COM = "COM4";                //定义蓝牙连接端口
    SerialPort BlueTooth = new SerialPort();    //定义蓝牙接口变量
    public char[] message = { '0', '0', '0', '0', '0', '\n', '\0' };   //定义unity给单片机发送的信息
    public int[] sum = new int[5];               //将接受到的单片机字符串转化为数字
    public char[] receive = new char[11];         //将接受到的单片机字符串转化为字符数组
    public string receive_string = "";          //接受到的单片机字符串
    void Awake()
    {
    }

    void Start() { 
    }
    void Update()
    {
        if (!BlueTooth.IsOpen)               //如果蓝牙没有打开，打开蓝牙
        {
            Connection();                    //连接蓝牙
            Thread.Sleep(100);               //延时一段时间
        }
        else
        {
            receive_string = BlueTooth.ReadLine();            //蓝牙接受字符串
            receive = receive_string.ToCharArray();           //将字符串转化为字符数组
          //  Debug.Log(receive_string);
            if (receive[0]=='a')                             //标签a,b,c,d,e分别为大拇指，食指，中指，无名指，小拇指的弯曲角度。
            {
                sum[0] = 0;
                for (int i=8;i>=1;i--)                       //将8位的二进制数据转化为十进制
                {
                    if(receive[i]=='1')
                    {
                        sum[0] = sum[0] + (int)Math.Pow(2,(8-i));
                    }
                    
                }                  
            }

            else if (receive[0] == 'b')
            {
                sum[1] = 0;
                for (int i = 8; i >= 1; i--)
                {
                    if (receive[i] == '1')
                    {
                        sum[1] = sum[1] + (int)Math.Pow(2, (8 - i));
                    }

                }
            }
            else if (receive[0] == 'c')
            {
                sum[2] = 0;
                for (int i = 8; i >= 1; i--)
                {
                    if (receive[i] == '1')
                    {
                        sum[2] = sum[2] + (int)Math.Pow(2, (8 - i));
                    }

                }
            }

            else if (receive[0] == 'd')
            {
                sum[3] = 0;
                for (int i = 8; i >= 1; i--)
                {
                    if (receive[i] == '1')
                    {
                        sum[3] = sum[3] + (int)Math.Pow(2, (8 - i));
                    }

                }
            }
            else if (receive[0] == 'e')
            {
                sum[4] = 0;
                for (int i = 8; i >= 1; i--)
                {
                    if (receive[i] == '1')
                    {
                        sum[4] = sum[4] + (int)Math.Pow(2, (8 - i));
                    }

                }
            }
            send(message);
        }
    }
    public void Connection()                 //蓝牙连接函数
    {
        Status = "正在连接蓝牙设备";
        BlueTooth.PortName = COM;
        BlueTooth.BaudRate = 9600;
        BlueTooth.DataBits = 8;
        BlueTooth.Open();
        BlueTooth.ReadTimeout = 1;
     //   BlueTooth.WriteTimeout = 0;
        Status = "蓝牙连接成功";
    }
    public void send(char[] x)              //蓝牙发送函数
    {
        BlueTooth.Write(x, 0, 6);
    }
}
