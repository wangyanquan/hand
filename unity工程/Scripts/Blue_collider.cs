using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_collider : MonoBehaviour {

    Blue myblue;

    void Awake()
    {
        myblue = GameObject.Find("B").GetComponent<Blue>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision x)
    {
        myblue.message[0] = '1';
    }
}
