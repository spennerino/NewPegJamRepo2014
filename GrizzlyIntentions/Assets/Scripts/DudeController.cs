using UnityEngine;
using System.Collections;

public class DudeController : MonoBehaviour
{
	public bool Dead = false;

	public float Speed = 400;
	public float TopSpeed = 750;
	public float SprintSpeed = 1000;

	private float MaximumSprint = 100;
	public float AvailableSprint = 100;
	private float SprintRegenSpeed = 0.025f;
	private bool isSprinting = false;

	private GameObject bloodSpray;

	public string horizontalAxis;
	public string verticalAxis;
	public string sprintButton;

	// Use this for initialization
	void Start()
	{
		bloodSpray = transform.Find("BloodSpray").gameObject;
		bloodSpray.particleSystem.Stop();
	}

	// Update is called once per frame
	void Update()
	{
		if (!Dead)
		{
			float horizontal = Input.GetAxis(horizontalAxis);
			float vertical = Input.GetAxis(verticalAxis);

			Vector3 force = new Vector3(horizontal, 0, vertical);



			if (!System.String.IsNullOrEmpty(sprintButton))
			{
				if (Input.GetButton(sprintButton) && AvailableSprint > 0 && rigidbody.velocity.magnitude < SprintSpeed)
				{
					rigidbody.AddForce(force.normalized * SprintSpeed * Time.deltaTime);

					if (rigidbody.velocity.magnitude > SprintSpeed)
					{
						rigidbody.velocity = rigidbody.velocity.normalized * SprintSpeed;
					}

					AvailableSprint--;
					isSprinting = true;
				}
				else
				{
					if (AvailableSprint < MaximumSprint)
					{
						AvailableSprint += SprintRegenSpeed;
					}
					isSprinting = false;
				}
			}

			if (!isSprinting)
			{
				rigidbody.AddForce(force.normalized * Speed * Time.deltaTime);

				if (rigidbody.velocity.magnitude > TopSpeed)
				{
					rigidbody.velocity = rigidbody.velocity.normalized * TopSpeed;
				}
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

				GameObject human = transform.Find("thehuman").gameObject;
				human.animation.Play("Die");
				bloodSpray.particleSystem.Play();
				bloodSpray.audio.Play();
				audio.Play();
			}
		}
	}
}
