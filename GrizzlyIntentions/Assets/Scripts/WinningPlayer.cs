using UnityEngine;
using System.Collections;

public static class WinningPlayer
{
	public static string lastPlayer;
	public static string material;

	public static void SetWinner(GameObject player)
	{
		lastPlayer = player.name;
		Debug.Log(lastPlayer);

		Renderer lastRenderer = player.transform.Find("thehuman/torso_geo/polySurface2").gameObject.GetComponent<Renderer>();
		material = lastRenderer.GetComponent<Renderer>().material.name;
		material = material.Substring(0, material.Length - 11);
	}
}
