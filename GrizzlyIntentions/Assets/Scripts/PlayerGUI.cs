using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour {

	private List<GameObject> 	currentPlayers;

	void Start()
	{
		Screen.showCursor = false;
		currentPlayers = PlayerUtil.GetPlayers ();
	}


	void OnGUI () {

		//dis ghetto...

		DudeController p1 = currentPlayers [0].GetComponent<DudeController> ();
		GUI.Box (new Rect (0,0,100,50), "Score: "  + p1.Score.ToString());

		if(currentPlayers.Count > 1)
		{
			DudeController p2 = currentPlayers [1].GetComponent<DudeController> ();
			GUI.Box (new Rect (Screen.width - 100,0,100,50), "Score: "  + p2.Score.ToString());
		}

		if(currentPlayers.Count > 2)
		{
			DudeController p3 = currentPlayers [2].GetComponent<DudeController> ();
			GUI.Box (new Rect (0,Screen.height - 50,100,50), "Score: "  + p3.Score.ToString());
		}

		if(currentPlayers.Count > 3)
		{
			DudeController p4 = currentPlayers [3].GetComponent<DudeController> ();
			GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Score: "  + p4.Score.ToString());
		}
	}
}
