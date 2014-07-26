using UnityEngine;
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
        Ray frontCheck = new Ray(this.transform.position, Vector3.forward);
        Debug.DrawRay(this.transform.position, Vector3.forward * 10);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(frontCheck, out hit, 10))
            {
                if (hit.collider.tag == "Player")
                {
                    hit.rigidbody.AddForce(Vector3.forward * 10000);
                }
            }
        }
    }
}
