using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anjian4 : MonoBehaviour {

    AudioSource myaudio;                  //按键音乐
    Animator myani;                       //按键动画
    Blue myblue;                         //蓝牙组件
    void Awake()
    {
        myaudio = GameObject.Find("4").GetComponent<AudioSource>();
        myani = gameObject.transform.parent.gameObject.GetComponent<Animator>();
        myblue = GameObject.Find("B").GetComponent<Blue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myani.GetCurrentAnimatorStateInfo(0).IsName("up_0"))                //如果当前按键是抬起状态，则不要启动按下动画
        {
            myani.SetBool("down", false);
        }
        gameObject.transform.parent.position = new Vector3(-4.24f, 4, -3.471f);   //每次固定一下按钮，以免按键晃动
    }
    void OnCollisionEnter(Collision x)
    {
        if (x.collider.name == "0_thumb_2" && myblue.sum[0] > 105)               //当检测到手指碰撞到按键，且手指为弯曲状态时
        {
            myaudio.Play();                                                     //启动按键声音，启动向下的动画。
            {
                myani.SetBool("down", true);
            }
        }
        else if (x.collider.name == "1_index_2" && myblue.sum[1] > 105)        //以下为检测到不同手指的情况时
        {
            myaudio.Play();
            {
                myani.SetBool("down", true);
            }
        }
        else if (x.collider.name == "2_middle_2" && myblue.sum[2] > 105)
        {
            myaudio.Play();
            {
                myani.SetBool("down", true);
            }
        }
        else if (x.collider.name == "3_ring_2" && myblue.sum[3] > 105)
        {
            myaudio.Play();
            {
                myani.SetBool("down", true);
            }
        }
        else if (x.collider.name == "4_pinky_2" && myblue.sum[4] > 105)
        {
            myaudio.Play();
            {
                myani.SetBool("down", true);
            }
        }
    }
    void OnCollisionStay(Collision x)
    {
    }
    void OnCollisionExit(Collision x)
    {
    }
}