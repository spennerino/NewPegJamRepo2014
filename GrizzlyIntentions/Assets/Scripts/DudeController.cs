﻿using UnityEngine;
using System.Collections;

public class DudeController : MonoBehaviour
{
	private bool Dead = false;
	public float Speed = 400;
	public float TopSpeed = 750;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (!Dead)
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			Vector3 force = new Vector3(horizontal, 0, vertical);
			rigidbody.AddForce(force * Speed * Time.deltaTime);

			if (rigidbody.velocity.magnitude > TopSpeed)
			{
				rigidbody.velocity = rigidbody.velocity.normalized * TopSpeed;
			}

			GameObject obj = transform.Find("thehuman").gameObject;
			if (rigidbody.velocity.magnitude > 0.1)
			{
				transform.forward = Vector3.Normalize(new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z));
				obj.animation.Play("Run");
			}
			else
			{
				obj.animation.Stop();
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (contact.otherCollider.tag == "Bear")
			{
				rigidbody.AddForce(new Vector3(Random.Range(-1000, 1000), 2000, Random.Range(-1000, 1000)));

				Dead = true;

				GameObject obj = transform.Find("thehuman").gameObject;
				obj.animation.Play("Die");
			}
		}
	}
}