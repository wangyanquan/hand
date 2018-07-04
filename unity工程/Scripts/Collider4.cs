using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider4 : MonoBehaviour
{

    public bool col_4;            //定义一个bool值，确定小拇指是否碰到物块且是否要抓取物块
    public Finger4 myfin4;        //小拇指脚本定义的变量
    Compare mycom;                //Compare脚本定义的变量
    void Awake()
    {
        col_4 = false;
        myfin4 = GameObject.Find("4_pinky_0").GetComponent<Finger4>();
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mycom.iszhi)                   //如果当前手势为展开手势，则此bool值为false；
            col_4 = false;
    }
    void OnCollisionStay(Collision a)     //碰撞停留时，检测碰撞到的物体是不是cube，手指的弯曲度是否大于80度，二者都满足，则确定要抓取cube。
    {
        if ((a.collider.tag == "wu") && (myfin4.a40.localRotation.eulerAngles.x >= 65))
 //  if(a.collider.tag == "wu")
        {
            col_4 = true;
        }

    }
    void OnCollisionEnter(Collision a)    //碰撞检测时，检测碰撞到的物体是不是cube，手指的弯曲度是否大于80度，二者都满足，则确定要抓取cube。
    {
        if ((a.collider.tag == "wu") && (myfin4.a40.localRotation.eulerAngles.x >= 65))
    //    if (a.collider.tag == "wu")
        {
            col_4 = true;
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
