﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fin_rotate2 : MonoBehaviour
{

    Blue myblue;                    //蓝牙组件
    void Awake()
    {
        myblue = GameObject.Find("B").GetComponent<Blue>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(new Vector3((myblue.sum[2] - 80) / 1.1f, 0, 0));       //中指的弯曲度通过蓝牙接受到的数据变化
        //    Debug.Log(transform.eulerAngles.x);
    }
}
