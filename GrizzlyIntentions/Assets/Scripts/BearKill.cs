using UnityEngine;
using System.Collections;

public class BearKill : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}

	void OnCollisionEnter(Collision collision)
	{
		// Debug-draw all contact points and normals
		foreach (ContactPoint contact in collision.contacts)
		{
			
		}

		// Play a sound if the colliding objects had a big impact.		
		if (collision.relativeVelocity.magnitude > 1)
		{

		}	
	}
}
