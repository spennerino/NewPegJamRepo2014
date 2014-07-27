using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour {

	private List<GameObject> 	currentPlayers;

	void Start()
	{
		currentPlayers = PlayerUtil.GetPlayers ();
	}


	void OnGUI () {

		DudeController p1 = currentPlayers [0].GetComponent<DudeController> ();
		//GUI.Box (new Rect (0,0,100,50), "Sprint: "  + p1.AvailableSprint.ToString());
		//GUI.Box (new Rect (Screen.width - 100,0,100,50), "Sprint: ");
		//GUI.Box (new Rect (0,Screen.height - 50,100,50), "Sprint: ");
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Sprint: ");

	}
}
