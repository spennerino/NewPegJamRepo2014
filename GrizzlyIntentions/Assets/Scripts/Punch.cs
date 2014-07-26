﻿using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray frontCheck = new Ray(this.transform.position, this.transform.forward);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(frontCheck, out hit, 5))
            {
                if (hit.collider.tag == "Bear")
                {
                    hit.rigidbody.AddForce(this.transform.forward * 10000);
                }
            }
        }
    }
}
