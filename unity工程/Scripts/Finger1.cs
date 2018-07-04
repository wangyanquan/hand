using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger1 : MonoBehaviour {

    public Transform a10;                 //食指中的一个关节
    private Transform a11;                //食指中的一个关节
    private Transform a12;                //食指中的一个关节
    private Collider1 mycollider;          //检测食指是否产生碰撞的组件
    Compare mycom;                        //检测当前手势为哪种手势的组件
    void Awake()
    {
        a10 = GameObject.Find("1_index_0").GetComponent<Transform>();
        a11 = GameObject.Find("1_index_1").GetComponent<Transform>();
        a12 = GameObject.Find("1_index_2").GetComponent<Transform>();
        mycollider = GameObject.Find("1_index_2").GetComponent<Collider1>();
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
 //       Debug.Log(a10.localRotation.eulerAngles.x);

        if (!mycom.iszhi)                                    //如果当前手势为握拳状态
        {
            
            if (a10.localRotation.eulerAngles.x <= 80)                          //如果关节还没有转到80度，则继续转，否则就停止
            {
                a10.Rotate(Vector3.right, 10, Space.Self);
                
            }
            else if((!mycollider.col_1)&&(a11.localRotation.eulerAngles.x<=80))      //如果关节还没有转到80度，则继续转，否则就停止
            {
                a11.Rotate(Vector3.right,10,Space.Self);
            }
            else if ((!mycollider.col_1)&&(a12.localRotation.eulerAngles.x<=80))     //如果关节还没有转到80度，则继续转，否则就停止
            {
                a12.Rotate(Vector3.right,10,Space.Self);
            }
        }
	}
}
