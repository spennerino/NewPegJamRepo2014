﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Punch : MonoBehaviour
{
	public string fire1Input;
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
			if (obj.rigidbody != null)
				gameObjects.Add(obj);
		}

		punchEffect = transform.Find("PunchEffect").gameObject;
		punchEffect.particleSystem.Stop();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown(fire1Input) && Time.time > nextPunch)
		{
			punchEffect.particleSystem.Play();
			nextPunch = Time.time + punchRate;

			foreach (GameObject obj in gameObjects)
			{
				Vector3 directionToTarget = transform.position - obj.transform.position;
				float angle = Vector3.Angle(transform.forward, directionToTarget);
				if (Mathf.Abs(angle) > 135
					&& ((Vector3.Distance(transform.position, obj.transform.position) < 7.5 && obj.tag == "Bear"))
					|| (Vector3.Distance(transform.position, obj.transform.position) < 4))
				{
					obj.transform.rigidbody.velocity = Vector3.zero;
					obj.transform.rigidbody.AddForce(this.transform.forward * 1500);

					DudeController myController = GetComponent<DudeController>();

					myController.Score += (ulong)punchPointBonus;
				}
			}
		}
	}
}
