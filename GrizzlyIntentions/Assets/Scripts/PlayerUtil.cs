using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerUtil
{

	private const int MAXPLAYERS = 4;
	private const string PLAYERPREFIX = "Dude";


	public static List<GameObject> GetPlayers()
	{
		List<GameObject> availablePlayers = new List<GameObject>();

		for (int i = 1; i <= MAXPLAYERS; i++)
		{
			GameObject tmpPlayer = GameObject.Find(PLAYERPREFIX + " " + i.ToString());

			if (tmpPlayer != null)
			{
				availablePlayers.Add(tmpPlayer);
			}
		}

		return availablePlayers;
	}

	public static List<GameObject> GetLivingPlayers()
	{
		List<GameObject> availablePlayers = new List<GameObject>();

		for (int i = 1; i <= MAXPLAYERS; i++)
		{
			GameObject tmpPlayer = GameObject.Find(PLAYERPREFIX + " " + i.ToString());

			if (tmpPlayer != null)
			{
				DudeController playerController = tmpPlayer.GetComponent<DudeController>();

				if (!playerController.Dead)
				{
					availablePlayers.Add(tmpPlayer);
				}
			}
		}

		return availablePlayers;
	}
}
