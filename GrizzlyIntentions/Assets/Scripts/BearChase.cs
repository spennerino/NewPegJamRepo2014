using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BearChase : MonoBehaviour
{
	private List<GameObject> availableVictims;
	public Transform currentVictim;

	private NavMeshAgent agent;

	private float roarRate = 5;
	private float nextRoar = 0;

	private float winTimer = 0;
	private float timeToWin = 100;


	private float currentBearSpeed =	0;
	private float bearSpeedMulti =		1.1f;
	private float bearSpeedMultiMulti =	1.5f;
	private float bearSpeedStartTime = 	0;
	private float bearSpeedInterval = 	15;


	// Use this for initialization
	void Start()
	{
		availableVictims = PlayerUtil.GetPlayers();

		agent = GetComponent<NavMeshAgent>();

		agent.updateRotation = true;
		agent.updatePosition = true;

		currentBearSpeed = agent.speed;
		bearSpeedStartTime = Time.time;
	}

	// Update is called once per frame
	void Update()
	{

		//increase bear speed every (bearSpeedInterval) seconds
		if ((Time.time - bearSpeedStartTime) >= bearSpeedInterval)
		{
			currentBearSpeed *= bearSpeedMulti;

			agent.speed = currentBearSpeed;

			Debug.Log ("OH SHAIT I'M SPEEDING UP: now at " +currentBearSpeed.ToString());

			bearSpeedMulti *= bearSpeedMultiMulti;
			bearSpeedStartTime = Time.time;
		}


		//find closest player to attack
		float lastDistance = 0;
		currentVictim = null;

		foreach (GameObject player in availableVictims)
		{
			DudeController playerController = player.GetComponent<DudeController>();

			if (!playerController.Dead)
			{
				float currentDistance = Vector3.Distance(transform.position, player.transform.position);

				if (currentDistance < lastDistance || lastDistance == 0)
				{
					currentVictim = player.transform;
					lastDistance = currentDistance;
				}
			}
		}


		if (currentVictim != null)
		{
			agent.SetDestination(currentVictim.position);
		}
		else
		{
			if (winTimer < timeToWin)
				winTimer++;
			else
				AutoFade.LoadLevel("WinScene", 0.5f, 0.5f, Color.black);
		}

		if (currentVictim != null && Vector3.Distance(currentVictim.position, transform.position) < 15 && Time.time > nextRoar)
		{
			nextRoar = Time.time + roarRate;
			audio.Play();
			Debug.Log("Roar");
		}

	}
}
