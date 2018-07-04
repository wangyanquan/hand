using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
public class Compare : MonoBehaviour {
    Cs2 mycs;
    private Mat wo;                 //用来获取握拳时的图像
    private Mat zhi;                //用来获取手展开时的图像
    public bool bool1;              //用来标记是否获取到第一张图，值为1时，表示正在获取第一张图片
    public bool bool2;              //用来标记是否获取到第二张图，值为1时，表示正在获取第二张图片
    public float time;              // 获取图像时的三秒倒计时的变量
    public bool iszhi;              //判断当前手势是哪种手势，是握拳还是展开
    void Awake () {
        mycs = gameObject.GetComponent<Cs2>();
        zhi = new Mat(50, 50, CvType.CV_8UC1);
        wo = new Mat(50, 50, CvType.CV_8UC1);
        bool1 = true;
        bool2 = true;
        time = 3;
        iszhi = true;
    }
	void Update ()
    {
        if (bool1)                                 //表示正在获取第一张图片   
        {
            time = time - Time.deltaTime;          //三秒倒计时
            if (time < 0)                          //三秒倒计时完成后，关闭获取第一张图片的状态，准备获取第二张图片
            {
                mycs.shishi.copyTo(zhi);           //获取第一张图像
                time = 3;
                bool1 = false;                     //获取完成，关闭第一种状态
            }

        }
        if ((bool2) && (!bool1))                   //进入获取第二张图像的状态
        {
            time = time - Time.deltaTime;           //三秒倒计时
            if (time < 0)
            {
                mycs.shishi.copyTo(wo);             //获取第二张图像
                bool2 = false;                      //获取第二张图像完成，关闭第二种状态
            }
        }
        byte[] shu1 = new byte[1];                  //当前场景的图像像素点的像素值
        byte[] shu2 = new byte[1];                  //手展开手势图像像素点的像素值
        byte[] shu3 = new byte[1];                  //手握拳手势图像像素点的像素值
        int count1 = 0; int count2 = 0;             //计数变量，看当前手势图同展开手势图与握拳手势图哪张图像更接近，数值越大越接近
        if (!bool1 && !bool2)
        {
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                {
                    mycs.shishi.get(i, j, shu1);        //获取图像像素点的像素值
                    zhi.get(i, j, shu2);
                    wo.get(i, j, shu3);
                    if (((shu1[0] == 255) && (shu2[0] == 255)) || ((shu1[0] == 0) && (shu2[0] == 0)))   //累加count1与count2，看哪个值更大
                    {
                        count1++;
                    }
                    if (((shu1[0] == 255) && (shu3[0] == 255)) || ((shu1[0] == 0) && (shu3[0] == 0)))
                    {
                        count2++;
                    }
                }
        }
        if (count1 >= count2)     //当前图像更接近于指向手势图像
            iszhi = true;
        else                       //否则更接近于握拳手势图像
            iszhi = false;
    }
}
