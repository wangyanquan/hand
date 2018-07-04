using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Ports;

public class Blue1 : MonoBehaviour
{



    public string Status;
    SerialPort BlueTooth = new SerialPort();
    string Data;
    char[] a;
    char[] cdata;
    char[] data1;
    int i;
    char[] data11;


    void Awake()
    {
        data1 = new char[6];
        data1[0] = 'a';
        data1[5] = '\0';
        data11 = new char[3];
    }
    void Start()
    {
        Connection();
        cdata = new char[100];
    }

    

    void Update()
    {
        if (!BlueTooth.IsOpen)
        {
            Connection();
            Thread.Sleep(100);
        }
            try
            {
                Data = BlueTooth.ReadLine();
                 Debug.Log(Data);
                cdata = Data.ToArray<char>();

                if ('a' == cdata[0])
                {           
                    for (i = 1; i <= 5; i++)
                    {
                        if ('b' == cdata[i])
                        {
                        //    Debug.Log(cdata);
                            break;
                        }
                        else
                            data1[i]=cdata[i];
                    }
                }
            }
            catch
            {

            }
        for (i=0;i<2;i++)
        {
            if (data1[i+1] != data11[i+1])
            {
                data11[i+1] = data1[i+1];
            }
        }
        
    }






    public void Connection()
    {
        Status = "正在连接蓝牙设备";
        BlueTooth = new SerialPort();
        BlueTooth.PortName = "COM7";
        BlueTooth.BaudRate = 9600;
        BlueTooth.DataBits = 8;
        BlueTooth.Open();
        BlueTooth.ReadTimeout = 1;
        BlueTooth.DataReceived += new SerialDataReceivedEventHandler(BlueToothDataReceived);
        Status = "蓝牙连接成功";
    }
    private void BlueToothDataReceived(object o, SerialDataReceivedEventArgs e)
    {
        Data = BlueTooth.ReadLine();
        Thread.Sleep(500);
        Debug.Log(Data);
        Debug.Log("ok");
    }
}

