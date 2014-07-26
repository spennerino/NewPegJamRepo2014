using UnityEngine;
using System.Collections;

public class BearRoll : MonoBehaviour {

	public GameObject parent;

	private NavMeshAgent parentNavMeshAgent;
	private float rotationSpeed = 0f;

	// Use this for initialization
	void Start()
	{
		parentNavMeshAgent = parent.GetComponent <NavMeshAgent> ();
		rotationSpeed = (parentNavMeshAgent.speed / 2) - 0.5f;
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Rotate (rotationSpeed, 0, 0, Space.Self);
	}

}
