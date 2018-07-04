using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider3 : MonoBehaviour
{

    public bool col_3;           //定义一个bool值，确定无名指是否碰到物块且是否要抓取物块
    public Finger3 myfin3;       //无名指脚本定义的变量
    public Compare mycom;        //Compare脚本定义的变量
    void Awake()
    {
        col_3 = false;
        myfin3 = GameObject.Find("3_ring_0").GetComponent<Finger3>();
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mycom.iszhi)             //如果当前手势为展开手势，则此bool值为false；
            col_3 = false;
    }
    void OnCollisionStay(Collision a)    //碰撞停留时，检测碰撞到的物体是不是cube，手指的弯曲度是否大于80度，二者都满足，则确定要抓取cube。
    {
        if ((a.collider.tag == "wu") && (myfin3.a30.localRotation.eulerAngles.x >= 80))
        {
            col_3 = true;
        }

    }
    void OnCollisionEnter(Collision a)      //碰撞检测时，检测碰撞到的物体是不是cube，手指的弯曲度是否大于80度，二者都满足，则确定要抓取cube。
    {
        if ((a.collider.tag == "wu") && (myfin3.a30.localRotation.eulerAngles.x >= 80))
        {
            col_3 = true;
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
