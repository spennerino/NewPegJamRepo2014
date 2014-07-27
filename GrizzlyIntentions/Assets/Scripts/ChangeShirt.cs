using UnityEngine;
using System.Collections;

public class ChangeShirt : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		Debug.Log(WinningPlayer.material);
		Material material = (Material)Resources.Load(WinningPlayer.material);
		if (material != null)
		{
			Transform dude = transform.Find("human_v009/torso_geo/polySurface2");
			Renderer renderer = dude.gameObject.GetComponent<Renderer>();
			renderer.material = material;
			WinningPlayer.lastPlayer = null;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
