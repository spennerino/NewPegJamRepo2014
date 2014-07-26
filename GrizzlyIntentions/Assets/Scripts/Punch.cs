using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour
{

    public string fire1Input;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray frontCheck = new Ray(this.transform.position, this.transform.forward);

        if (Input.GetButton(fire1Input))
        {
            if (Physics.Raycast(frontCheck, out hit, 5))
            {
                if (hit.collider.tag == "Player")
                {
                    hit.rigidbody.AddForce(this.transform.forward * 10000);
                }
            }
        }
    }
}
