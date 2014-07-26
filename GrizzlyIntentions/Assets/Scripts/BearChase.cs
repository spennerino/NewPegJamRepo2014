using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BearChase : MonoBehaviour
{
	private List<GameObject> 	availableVictims;
	public  Transform 			currentVictim;

	private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
		availableVictims = PlayerUtil.GetPlayers ();

		agent = GetComponent<NavMeshAgent> ();

		agent.updateRotation =	true;
		agent.updatePosition = 	true;
    }

    // Update is called once per frame
    void Update()
    {
		float lastDistance = 0;

		currentVictim = null;

		foreach (GameObject player in availableVictims)
		{
			DudeController playerController = player.GetComponent<DudeController>();

			if(!playerController.Dead)
			{
				float currentDistance = Vector3.Distance(transform.position, player.transform.position);

				if(currentDistance < lastDistance || lastDistance == 0)
				{
					currentVictim = player.transform;
					lastDistance = currentDistance;
				}
			}
		}

		if(currentVictim != null)
		{
			agent.SetDestination (currentVictim.position);
		}
    }
}
