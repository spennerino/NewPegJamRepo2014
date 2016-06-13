using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Punch : MonoBehaviour
{
	public string punchInput;
	private float punchRate = 1;
	private float nextPunch = 0;

	private int punchPointBonus = 5000;

	private GameObject punchEffect;
	private List<GameObject> gameObjects = new List<GameObject>();

	void Start()
	{
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
		{
			if (this.gameObject != obj)
				gameObjects.Add(obj);
		}
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bear"))
		{
			if (obj.GetComponent<Rigidbody>() != null)
				gameObjects.Add(obj);
		}

		punchEffect = this.transform.Find("PunchEffect").gameObject;
		punchEffect.GetComponent<ParticleSystem>().Stop();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown(punchInput) && Time.time > nextPunch)
		{
			punchEffect.GetComponent<ParticleSystem>().Play();
			punchEffect.GetComponent<AudioSource>().Play();
			nextPunch = Time.time + punchRate;

			foreach (GameObject obj in gameObjects)
			{
				Vector3 directionToTarget = this.transform.position - obj.transform.position;
				float angle = Vector3.Angle(this.transform.forward, directionToTarget);
				if (Mathf.Abs(angle) > 135
					&& ((Vector3.Distance(this.transform.position, obj.transform.position) < 7.5 && obj.tag == "Bear"))
					|| (Vector3.Distance(this.transform.position, obj.transform.position) < 4))
				{
					obj.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
					obj.transform.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1500);

					DudeController myController = GetComponent<DudeController>();

					myController.Score += punchPointBonus;
				}
			}
		}
	}
}
