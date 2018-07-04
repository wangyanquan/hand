using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Childcs : MonoBehaviour {
    private Collider1 myfin1;               //食指脚本定义变量
    private Collider2 myfin2;               //中指脚本定义变量
    private Collider3 myfin3;                 //无名指脚本定义变量
    private Collider4 myfin4;                //小拇指脚本定义变量
    Transform parent;                       //手的位置信息
    private RigidbodyConstraints dongjie;      //锁定cude的旋转与移动
    Compare mycom;                          //确定当前为哪种手势

    void Awake()
    {
        myfin1 = GameObject.Find("1_index_2").GetComponent<Collider1>();
        myfin2 = GameObject.Find("2_middle_2").GetComponent<Collider2>();
        myfin3 = GameObject.Find("3_ring_2").GetComponent<Collider3>();
        myfin4 = GameObject.Find("4_pinky_2").GetComponent<Collider4>();
        parent = GameObject.Find("Hand_right_2").GetComponent<Transform>();
        dongjie = RigidbodyConstraints.FreezeAll;
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();


    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(mycom.iszhi)         //当手势为展开时的状态
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;   //解冻cube为自由状态
            transform.SetParent(null);                                                     // cube设置为没有父物体状态
        }
	}
    void OnCollisionStay(Collision a)                  //当cube与外界发生碰撞时
    {
        //Debug.Log(a.collider.name);
        if ((myfin1.col_1 || myfin2.col_2 || myfin3.col_3 || myfin4.col_4)&&(a.collider.name!= "Plane") && (a.collider.tag != "wu"))  //判断发生碰撞的物体是否为手指
        {
            transform.SetParent(parent);   //是手指是，将cube的父物体设置为手指
            gameObject.GetComponent<Rigidbody>().constraints = dongjie;    //将cube冻结，防止其旋转与移动

        }
    }
}
