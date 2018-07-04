using OpenCVForUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCVForUnitySample;
using UnityEngine.UI;

public class Cs2 : MonoBehaviour
{

    private Mat tu;                    //定义一个图片变量，用来接收摄像头的图片 
    private WebCamTexture mycap;        //定义一个摄像头变量，用来开启摄像头。
    private string deviceName;         //摄像头名字
    private Mat a;                     //定义YUV空间的图片变量
    private Mat b;                     //存放U通道的图像信息。
    public Mat b1;                      //存放变量b的备份
    public int fa = 136;                //opencv函数中用来区分红色与其他颜色的阈值。
    List<Mat> c;                        //定义一个图像数组，用来接收YUV图像通道
    private OpenCVForUnity.Size size;   //定义一个图片尺寸的变量
    Scalar color;                       //定义一个颜色变量，用于手势矩形框的绘制
    private Mat hier;                  //findContours函数所需要的参数，无意义
    public float s;                     //手型轮廓的面积
    public OpenCVForUnity.Rect rect1;   //定义一个手型轮廓边框（矩形框）变量
    public double x;                    //定义轮廓的边缘点的坐标变量x
    public double y;                    //定义轮廓的边缘点的坐标变量y
    public Mat shishi;                  //定义一个新的图像变量，用来接收jie变量图像的缩放图像
    public bool sb;
    void Awake()
    {
        fa = 160;                                         //opencv函数中用来区分红色与其他颜色的阈值。
        mycap = new WebCamTexture();                      //初始化摄像头
        WebCamDevice[] devices = WebCamTexture.devices;   //定义并获取摄像头数组
        deviceName = devices[0].name;                     //获取当前摄像头名字
        mycap = new WebCamTexture(deviceName, 640, 480);   //用摄像头名字，宽度与高度来初始化摄像头
        tu = new Mat(480, 640, CvType.CV_8UC3);            //用高度，宽度，图像类别来初始化图片
        a = new Mat(480, 640, CvType.CV_8UC3);             //定义YUV空间的图片变量
        b = new Mat(480, 640, CvType.CV_8UC1);             //存放U通道的图像信息。
        b1 = new Mat(480, 640, CvType.CV_8UC1);            //存放变量b的备份
        c = new List<Mat>();                               //定义一个图像数组
        size = new Size(50, 50);                            //将图片大小初始化为50*50的
        color = new Scalar(255);                           //将颜色变量初始化为白色
        hier = new Mat();                                  //findContours函数所需要的参数，无意义
        rect1 = new OpenCVForUnity.Rect(1, 1, 1, 1);       //定义一个手型轮廓边框（矩形框）变量
        shishi = new Mat(50, 50, CvType.CV_8UC1);           //定义一个新的图像变量，用来接收jie变量图像的缩放图像
    }

    void Update()
    {
        mycap.Play();                                               //开启摄像头
        Utils.webCamTextureToMat(mycap, tu);                        //将摄像头拍摄的场景转化为图片信息。
        Imgproc.cvtColor(tu, a, 37);                                //将RGB空间转化为YUV空间
        Core.split(a, c);                                            //将YUV空间分开， 存到变量C中。
        b = new Mat(480, 640, CvType.CV_8UC1);                        //定义一个单通道的图片变量。
        b = c[1];                                                       //将U通道赋值给b变量，到此就完成了提取U通道。
        Imgproc.threshold(b, b, fa, 255, Imgproc.THRESH_BINARY);       //将b图像转化为二值图
        //Imgproc.threshold(b, b, fa, 255, Imgproc.THRESH_BINARY_INV);
        b.copyTo(b1);                                                       //将U通道的信息拷贝给b1变量
        List<MatOfPoint> contours = new List<MatOfPoint>();                 //定义一个Matofpoint类型的变量数组，存放图像轮廓信息
        Imgproc.findContours(b, contours, hier, 0, 2);                //寻找b图像中的轮廓，存储到contous变量数组中。
        ////0 1 2 3
        s = 0;                                                          //轮廓面积变量
        x = 0; y = 480;                                                 //轮廓的边缘点的坐标变量
        List<MatOfPoint> selectcol = new List<MatOfPoint>();            //定义一个数组，用来存放手势轮廓
        foreach (MatOfPoint i in contours)                              //循环所有轮廓，找出面积大于5000的轮廓
        {
            if (Mathf.Abs((float)Imgproc.contourArea(i)) > 5000)
            {
                selectcol.Add(i);                                      //将轮廓面积大于5000的变量存到selectcol数组中
            }

        }
        if (selectcol.Count == 1)                                      //如果只有一个轮廓，就是手型轮廓
        {
            s = Mathf.Abs((float)Imgproc.contourArea(selectcol[0]));
            rect1 = Imgproc.boundingRect(selectcol[0]);                //求出轮廓的手型边缘矩形框
            Point[] dian = selectcol[0].toArray();                       //提取轮廓点
            foreach (Point dian1 in dian)
            {
                if (dian1.y < y)                                        //选出轮廓的最低点
                {
                    y = dian1.y;
                    x = dian1.x;
                }
            }
        }
        else if (selectcol.Count == 2)                                  //如果两个轮廓，选择下方的轮廓作为手型轮廓
        {
            if (selectcol[0].toArray()[0].y < selectcol[1].toArray()[0].y)
            {
                s = Mathf.Abs((float)Imgproc.contourArea(selectcol[0]));
                rect1 = Imgproc.boundingRect(selectcol[0]);
                Point[] dian = selectcol[0].toArray();
                foreach (Point dian1 in dian)
                {
                    if (dian1.y < y)                                     //选出轮廓的最低点
                    {
                        y = dian1.y;
                        x = dian1.x;
                    }
                }
            }
            else                                                           //轮廓较多的情况时，固定x,y,表示没有找到
            {
                s = Mathf.Abs((float)Imgproc.contourArea(selectcol[1]));
                rect1 = Imgproc.boundingRect(selectcol[1]);
                Point[] dian = selectcol[1].toArray();
                foreach (Point dian1 in dian)
                {
                    if (dian1.y < y)
                    {
                        y = dian1.y;
                        x = dian1.x;
                    }
                }
            }
        }
        else
        {
            x = 320; y = 200;
        }
        //    Debug.Log(selectcol.Count);
        Imgproc.rectangle(b1, rect1.tl(), rect1.br(), color);          //在图像b1上画出矩形框
        Mat jie = new Mat(b1, rect1);                                  //截取图像b1内画出的矩形框
        Imgproc.resize(jie, shishi, size);                              //调整图像的大小，用来在UI界面中显示
    }
}