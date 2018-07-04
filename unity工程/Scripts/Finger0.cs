using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger0 : MonoBehaviour {              //大拇指脚本，用来控制大拇指的弯曲


    Vector3 a00 = new Vector3(40, -16, -10);       //大拇指弯曲后的三个关节中一个关节的弯曲角度
    Vector3 a01 = new Vector3(-15, 10, -10);       //大拇指弯曲后的三个关节中一个关节的弯曲角度
    Vector3 a02 = new Vector3(-10, 20, -8);        //大拇指弯曲后的三个关节中一个关节的弯曲角度

    Transform h00;                                  //关节位置组件
    Transform h01;                                  //关节位置组件
    Transform h02;                                  //关节位置组件

    public Compare mycom;                          //获取当前手势为何种手势的组件

    void Awake()
    {
        h00 = GameObject.Find("0_thumb_0").GetComponent<Transform>();
        h01 = GameObject.Find("0_thumb_1").GetComponent<Transform>();
        h02 = GameObject.Find("0_thumb_2").GetComponent<Transform>();
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!mycom.iszhi)                               //如果为握拳手势，三个关节分别弯曲到指定角度。
        {
            h00.localRotation = Quaternion.Euler(a00);
            h01.localRotation = Quaternion.Euler(a01);
            h02.localRotation = Quaternion.Euler(a02);
        }
	}


}
