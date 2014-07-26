using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.anyKey)
		{
			AutoFade.LoadLevel("MainScene", 0.5f, 0.5f, Color.black);
		}
	}
}
