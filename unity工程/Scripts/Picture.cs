using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnity;
using UnityEngine.UI;

public class Picture : MonoBehaviour {

    Cs2 mycs2;                                   //用来获取手势图像信息
    RawImage image;                              //定义UI图像组件
    public Texture2D xianshi;                    //定义unity图像变量
    void Awake ()
    {
        xianshi = new Texture2D(640,480);
        mycs2 = GameObject.Find("Main Camera").GetComponent<Cs2>();
        image = gameObject.GetComponent<RawImage>();     
	}
	
	// Update is called once per frame
	void Update () {
        Utils.matToTexture2D(mycs2.b1,xianshi);  //将opencv图像格式转化为texture2D
        image.texture = xianshi;                 //显示图像
    }
}
