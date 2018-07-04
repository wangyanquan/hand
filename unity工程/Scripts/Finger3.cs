using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger3 : MonoBehaviour
{

    public Transform a30;
    private Transform a31;
    private Transform a32;
    private Collider3 mycollider_3;
    Compare mycom;
    void Awake()
    {
        a30 = GameObject.Find("3_ring_0").GetComponent<Transform>();
        a31 = GameObject.Find("3_ring_1").GetComponent<Transform>();
        a32 = GameObject.Find("3_ring_2").GetComponent<Transform>();
        mycollider_3 = GameObject.Find("3_ring_2").GetComponent<Collider3>();
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

            if (a30.localRotation.eulerAngles.x <= 80)
            {
                a30.Rotate(Vector3.right, 10, Space.Self);
            }
            else if ((!mycollider_3.col_3) && (a31.localRotation.eulerAngles.x <= 80))
            {
                a31.Rotate(Vector3.right, 10, Space.Self);
            }
            else if ((!mycollider_3.col_3) && (a32.localRotation.eulerAngles.x <= 80))
            {
                a32.Rotate(Vector3.right, 10, Space.Self);
            }
        }
    }
}
