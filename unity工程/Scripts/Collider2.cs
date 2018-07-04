using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2 : MonoBehaviour
{

    public bool col_2;           //定义一个bool值，确定中指是否碰到物块且是否要抓取物块
    public Finger2 myfin2;       //中指脚本定义的变量
    public Compare mycom;        //Compare脚本定义的变量
    void Awake()
    {
        col_2 = false;
        myfin2 = GameObject.Find("2_middle_0").GetComponent<Finger2>();
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mycom.iszhi)       //如果当前手势为展开手势，则此bool值为false；
            col_2 = false;
    }
    void OnCollisionStay(Collision a)     //碰撞停留时，检测碰撞到的物体是不是cube，手指的弯曲度是否大于80度，二者都满足，则确定要抓取cube。
    {
        if ((a.collider.tag == "wu") && (myfin2.a20.localRotation.eulerAngles.x >= 80))
        {
            col_2 = true;
        }

    }
    void OnCollisionEnter(Collision a)
    {
        if ((a.collider.tag == "wu") && (myfin2.a20.localRotation.eulerAngles.x >= 80))   //碰撞检测时，检测碰撞到的物体是不是cube，手指的弯曲度是否大于80度，二者都满足，则确定要抓取cube。
        {
            col_2 = true;
        }

    }
    //void OnCollisionExit(Collision a)
    //{
    //    if (a.collider.tag == "wu")
    //    {
    //        col = false;
    //    }
    //}
}
