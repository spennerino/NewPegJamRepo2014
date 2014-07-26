using UnityEngine;
using System.Collections;

public class BearChase : MonoBehaviour
{
    public Transform victim;
	private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
		agent = GetComponent<NavMeshAgent> ();
		
		agent.updateRotation =	true;
		agent.updatePosition = 	true;
    }

    // Update is called once per frame
    void Update()
    {
		agent.SetDestination (victim.position);
    }
}
