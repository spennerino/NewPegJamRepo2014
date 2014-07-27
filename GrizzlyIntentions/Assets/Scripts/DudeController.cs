using UnityEngine;
using System.Collections;

public class DudeController : MonoBehaviour
{
	public bool Dead = false;

	public int Score = 0;

	public float Speed = 750;
	public float TopSpeed = 1250;
	public float SprintSpeed = 1500;
	public float TopSprintSpeed = 3000;

	private bool isSprinting = false;
	private float sprintStartTime = 0;
	private float maxSprintTime = 2;
	private float sprintCooldown = 5;
	private float sprintCooldownStartTime = 0;

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
			Score++;

			float horizontal = Input.GetAxis(horizontalAxis);
			float vertical = Input.GetAxis(verticalAxis);

			Vector3 force = new Vector3(horizontal, 0, vertical);


			//sprint button mapping
			if (!System.String.IsNullOrEmpty(sprintButton))
			{
				if (Input.GetButton(sprintButton))
				{
					if (sprintStartTime == 0)
					{
						sprintStartTime = Time.time;
					}

					if ((Time.time - sprintStartTime) <= maxSprintTime)
					{
						Debug.Log("I'M SPRINTING");
						isSprinting = true;
					}
				}
			}


			//sprint cooldown - if sprint is exceeded, start cooldown
			if ((Time.time - sprintStartTime) >= maxSprintTime)
			{
				isSprinting = false;

				if (sprintCooldownStartTime == 0)
				{
					sprintCooldownStartTime = Time.time;
				}

				if ((Time.time - sprintCooldownStartTime) > sprintCooldown)
				{
					Debug.Log("I CAN SPRINT ONCE MORE");
					sprintStartTime = 0;
					sprintCooldownStartTime = 0;
				}
			}


			//apply movement force
			if (isSprinting)
			{
				rigidbody.AddForce(force.normalized * SprintSpeed * Time.deltaTime);

				if (rigidbody.velocity.magnitude > TopSprintSpeed)
				{
					rigidbody.velocity = rigidbody.velocity.normalized * TopSprintSpeed;
				}
			}
			else
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
