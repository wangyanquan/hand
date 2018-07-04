using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger2 : MonoBehaviour
{

    public Transform a20;
    private Transform a21;
    private Transform a22;
    private Collider2 mycollider_2;
    Compare mycom;
    void Awake()
    {
        a20 = GameObject.Find("2_middle_0").GetComponent<Transform>();
        a21 = GameObject.Find("2_middle_1").GetComponent<Transform>();
        a22 = GameObject.Find("2_middle_2").GetComponent<Transform>();
        mycollider_2 = GameObject.Find("2_middle_2").GetComponent<Collider2>();
        mycom = GameObject.Find("Main Camera").GetComponent<Compare>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //       Debug.Log(a10.localRotation.eulerAngles.x);

        if (!mycom .iszhi)
        {

            if (a20.localRotation.eulerAngles.x <= 80)
            {
                a20.Rotate(Vector3.right, 10, Space.Self);
            }
            else if ((!mycollider_2.col_2) && (a21.localRotation.eulerAngles.x <= 80))
            {
                a21.Rotate(Vector3.right, 10, Space.Self);
            }
            else if ((!mycollider_2.col_2) && (a22.localRotation.eulerAngles.x <= 80))
            {
                a22.Rotate(Vector3.right, 10, Space.Self);
            }
        }
    }
}
