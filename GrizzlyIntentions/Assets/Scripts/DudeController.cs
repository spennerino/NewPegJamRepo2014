using UnityEngine;
using System.Collections;

public class DudeController : MonoBehaviour
{
	public float Speed = 400;
	public float TopSpeed = 750;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 force = new Vector3(horizontal, 0, vertical);

		rigidbody.AddForce(force * Speed * Time.deltaTime);

		if (rigidbody.velocity.magnitude > TopSpeed)
		{
			rigidbody.velocity = rigidbody.velocity.normalized * TopSpeed;
		}
	}
}
