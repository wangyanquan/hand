using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {   //发射球体脚本
    public GameObject mycube;
    Transform mytransform;
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {         //实例化球体，并给与向上的力量
        Vector3 vec = new Vector3(-5,2,0);
        GameObject obj = Instantiate(mycube,vec, Quaternion.identity);
        Rigidbody myrigibody = obj.GetComponent<Rigidbody>();
        myrigibody.AddForce(new Vector3(0,1000,0));
	}
}
