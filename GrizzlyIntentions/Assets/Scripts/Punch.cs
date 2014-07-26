using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour
{
	public string fire1Input;
	private float punchRate = 2;
	private float nextPunch = 0;

	private GameObject punchEffect;

	void Start()
	{
		punchEffect = transform.Find("PunchEffect").gameObject;
		punchEffect.particleSystem.Stop();
	}

	// Update is called once per frame
	void Update()
	{
		RaycastHit hit;
		Ray frontCheck = new Ray(this.transform.position, this.transform.forward);

		if (Input.GetButton(fire1Input) && Time.time > nextPunch)
		{
			punchEffect.particleSystem.Play();
			nextPunch = Time.time + punchRate;

			if (Physics.Raycast(frontCheck, out hit, 5))
			{
				if (hit.collider.tag == "Player" || hit.collider.tag == "Bear")
				{
					hit.rigidbody.AddForce(this.transform.forward * 1000);
				}
			}
		}
	}
}
