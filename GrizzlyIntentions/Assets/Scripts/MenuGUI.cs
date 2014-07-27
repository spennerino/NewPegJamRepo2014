using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public string p1Name, p2Name, p3Name, p4Name;

	// Use this for initialization
	void Start () {
	
		p1Name = System.String.IsNullOrEmpty(PlayerPrefs.GetString("P1Name")) ? "Player 1" : PlayerPrefs.GetString("P1Name");
		p2Name = System.String.IsNullOrEmpty(PlayerPrefs.GetString("P2Name")) ? "Player 2" : PlayerPrefs.GetString("P2Name");
		p3Name = System.String.IsNullOrEmpty(PlayerPrefs.GetString("P3Name")) ? "Player 3" : PlayerPrefs.GetString("P3Name");
		p4Name = System.String.IsNullOrEmpty(PlayerPrefs.GetString("P4Name")) ? "Player 4" : PlayerPrefs.GetString("P4Name");

	}
	
	void OnGUI ()
	{
		GUIStyle style = new GUIStyle ();
		style.alignment = TextAnchor.MiddleLeft;
		style.fixedWidth = 200;
		style.fixedHeight = 28;
		style.normal.textColor = Color.black;


		GUILayout.BeginArea (new Rect (Screen.width / 4, (Screen.height / 3) *2, Screen.width / 2, Screen.height / 3));

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Player 1 Name:", style, null);
		p1Name = GUILayout.TextField (p1Name);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Player 2 Name:", style, null);
		p2Name = GUILayout.TextField (p2Name);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Player 3 Name:", style, null);
		p3Name = GUILayout.TextField (p3Name);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Player 4 Name:", style, null);
		p4Name = GUILayout.TextField (p4Name);
		GUILayout.EndHorizontal ();

		GUILayout.Space (20);

		if(GUILayout.Button("Start Game"))
		{
			PlayerPrefs.SetString("P1Name", p1Name);
			PlayerPrefs.SetString("P2Name", p2Name);
			PlayerPrefs.SetString("P3Name", p3Name);
			PlayerPrefs.SetString("P4Name", p4Name);

			PlayerPrefs.Save();

			AutoFade.LoadLevel("MainScene", 0.5f, 0.5f, Color.black);
		}

		GUILayout.EndArea ();
	}
}
