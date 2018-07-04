using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger4 : MonoBehaviour
{

    public Transform a40;
    private Transform a41;
    private Transform a42;
    private Collider4 mycollider_4;
    Compare mycom;
    void Awake()
    {
        a40 = GameObject.Find("4_pinky_0").GetComponent<Transform>();
        a41 = GameObject.Find("4_pinky_1").GetComponent<Transform>();
        a42 = GameObject.Find("4_pinky_2").GetComponent<Transform>();
        mycollider_4 = GameObject.Find("4_pinky_2").GetComponent<Collider4>();
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //       Debug.Log(a10.localRotation.eulerAngles.x);

        if (!mycom.iszhi)
        {

            if (a40.localRotation.eulerAngles.x <= 65)
            {
                a40.Rotate(Vector3.right, 10, Space.Self);
            }
            else if ((!mycollider_4.col_4) && (a41.localRotation.eulerAngles.x <= 70))
            {
                a41.Rotate(Vector3.right, 10, Space.Self);
            }
            else if ((!mycollider_4.col_4) && (a42.localRotation.eulerAngles.x <= 70))
            {
                a42.Rotate(Vector3.right, 10, Space.Self);
            }
        }
    }
}
