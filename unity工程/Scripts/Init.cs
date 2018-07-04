using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour { //此脚本用于在初始化时建立一些cube，然后隔一段时间销毁，然后建立，不断重复

    public GameObject pre;
    void inits()
    {
        for (int i = 0; i < transform.childCount; i++)              //销毁原先遗留的cube
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 1; i <= 3; i++)                              //实例化cube，且将这些cube放到同一个父物体下
        {
            for (int j = 1; j <= 4; j++)
            {
                GameObject my = GameObject.Instantiate(pre, new Vector3((float)(-10 + 2.5 * j), (float)(-1.25 + 2.5 * i), 2), Quaternion.identity);
                my.transform.SetParent(gameObject.transform);
            }
        }
    }
    void setposition()              //为这些cube排好位置
    {
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                transform.GetChild(i * j).transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.GetChild(i * j).transform.position = new Vector3((float)(-7 + 2.5 * j), (float)(-1.25 + 2.5 * i), 0);


            }
        }
    }
	void Awake () {
        inits();
        InvokeRepeating("inits", 0, 10);   //每十秒钟重复执行
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
