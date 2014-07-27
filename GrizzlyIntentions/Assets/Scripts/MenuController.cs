using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
	public string nextScene = "";

	public float speedMod = 0.5f;
	private float startIncrement = 0.01f;
	private float endIncrement = 0.25f;
	private float range = 0.0625f;
	private float progress = 0f;
	public Vector3 startPosition = Vector3.zero;
	public Vector3 endPosition = Vector3.zero;
	private bool complete = false;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!complete && progress < 1f)
		{
			progress += startIncrement * speedMod;
		}
		else
		{
			complete = true;
		}

		if (complete)
		{
			if (progress < 1f)
			{
				progress += endIncrement * speedMod;
			}
			else
			{
				startPosition = endPosition;
				endPosition = new Vector3
					(
						startPosition.x + Random.Range(-range, range),
						startPosition.y + Random.Range(-range, range),
						startPosition.z + Random.Range(-range, range)
					);
				progress = 0;
			}
		}
		transform.position = Vector3.Lerp(startPosition, endPosition, progress);

		/*
		if (complete && Input.anyKey)
		{
			AutoFade.LoadLevel(nextScene, 0.5f, 0.5f, Color.black);
		}
		*/
	}
}
