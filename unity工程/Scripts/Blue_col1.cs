﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_col1 : MonoBehaviour
{

    private Blue myblue;                 //蓝牙组件
    void Awake()
    {
        myblue = GameObject.Find("B").GetComponent<Blue>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, 0, 1f);                //每次固定一下食指的位置
    }
    void OnCollisionEnter(Collision a)                                  //每次指尖发生碰撞时，将需要发送的信息置一
    {
        myblue.message[1] = '1';
    }
    void OnCollisionStay(Collision a)                                //每次指尖发生碰撞时，将需要发送的信息置一
    {
        myblue.message[1] = '1';
    }
    void OnCollisionExit(Collision a)                                 //每次指尖不产生碰撞时，将需要发送的信息清零
    {
        myblue.message[1] = '0';
    }
}
