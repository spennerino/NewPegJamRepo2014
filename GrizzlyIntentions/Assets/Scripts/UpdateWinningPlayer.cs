using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpdateWinningPlayer : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		WinningPlayer.lastPlayer = null;
	}

	// Update is called once per frame
	void Update()
	{
		List<GameObject> remainingPlayers = PlayerUtil.GetLivingPlayers();
		if (remainingPlayers.Count == 1 && WinningPlayer.lastPlayer == null)
		{
			WinningPlayer.SetWinner(remainingPlayers[0]);
			Debug.Log("Last Player " + WinningPlayer.lastPlayer);
		}
	}
}
