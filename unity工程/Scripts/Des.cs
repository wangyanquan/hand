using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour {    //喷射出的球体脚本

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position.y<=1)        //当喷出的球体掉落到一定高度，便销毁
        {
            Destroy(gameObject);
        }
	}
}
