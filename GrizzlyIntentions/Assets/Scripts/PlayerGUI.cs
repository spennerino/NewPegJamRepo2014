using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour {

	private List<GameObject> 	currentPlayers;

	public string p1Name, p2Name, p3Name, p4Name;
	private bool p1Playing, p2Playing, p3Playing, p4Playing;
	
	// Use this for initialization
	void Start () {
		
		p1Name = PlayerPrefs.GetString ("P1Name");
		p2Name = PlayerPrefs.GetString ("P2Name");
		p3Name = PlayerPrefs.GetString ("P3Name");
		p4Name = PlayerPrefs.GetString ("P4Name");

		currentPlayers = PlayerUtil.GetPlayers ();

		Screen.showCursor = false;
	}


	void OnGUI () {

		//dis ghetto...

		DudeController p1 = currentPlayers [0].GetComponent<DudeController> ();
		p1.PublicName = p1Name;
		GUI.Box (new Rect (0,0,100,40), p1Name + "\r\n"  + p1.Score.ToString());

		if(currentPlayers.Count > 1)
		{
			DudeController p2 = currentPlayers [1].GetComponent<DudeController> ();
			p2.PublicName = p2Name;
			GUI.Box (new Rect (Screen.width - 100,0,100,40), p2Name + "\r\n"  + p2.Score.ToString());
		}

		if(currentPlayers.Count > 2)
		{
			DudeController p3 = currentPlayers [2].GetComponent<DudeController> ();
			p3.PublicName = p3Name;
			GUI.Box (new Rect (0,Screen.height - 40,100,40), p3Name + "\r\n"  + p3.Score.ToString());
		}

		if(currentPlayers.Count > 3)
		{
			DudeController p4 = currentPlayers [3].GetComponent<DudeController> ();
			p4.PublicName = p4Name;
			GUI.Box (new Rect (Screen.width - 100,Screen.height - 40,100,40), p4Name + "\r\n"  + p4.Score.ToString());
		}
	}
}
