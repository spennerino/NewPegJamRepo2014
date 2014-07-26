using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BearChase : MonoBehaviour
{
	private const int MAXPLAYERS = 4;

    public Transform victim;

	private List<GameObject> availableVictims;
	private Transform currentVictim;
	private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
		availableVictims = new List<GameObject> ();
		for(int i = 1; i <= MAXPLAYERS; i++)
		{
			GameObject tmpPlayer = GameObject.Find("Dude " + i.ToString());
			
			if(tmpPlayer != null)
			{
				availableVictims.Add(tmpPlayer);
			}
		}

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
