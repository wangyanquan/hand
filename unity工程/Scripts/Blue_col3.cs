﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_col3 : MonoBehaviour
{

    private Blue myblue;                   //蓝牙组件
    void Awake()
    {
        myblue = GameObject.Find("B").GetComponent<Blue>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 1);       //每次固定一下中指的位置
    }
    void OnCollisionEnter(Collision a)                        //每次指尖发生碰撞时，将需要发送的信息置一
    {
        myblue.message[3] = '1';
    }
    void OnCollisionStay(Collision a)                         //每次指尖发生碰撞时，将需要发送的信息置一
    {
        myblue.message[3] = '1';
    }
    void OnCollisionExit(Collision a)                        //每次指尖不产生碰撞时，将需要发送的信息清零
    {
        myblue.message[3] = '0';
    }
}
