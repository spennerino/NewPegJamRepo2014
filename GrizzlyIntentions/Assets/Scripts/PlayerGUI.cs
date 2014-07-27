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
		
		GUIStyle boxstyle = new GUIStyle ();
		boxstyle.normal.background = MakeTexture (new Color(0,0,0, 0.5f));



		DrawRectangle (new Rect (0, 0, 10, 40), Color.red);

		GUILayout.BeginArea (new Rect (10, 0, 100, 40), boxstyle);
		GUILayout.Label( p1Name + "\r\n" + p1.Score.ToString() );
		GUILayout.EndArea ();


		if(currentPlayers.Count > 1)
		{
			DudeController p2 = currentPlayers [1].GetComponent<DudeController> ();

			DrawRectangle (new Rect (Screen.width - 10,0,10,40), Color.yellow);
			
			GUILayout.BeginArea (new Rect (Screen.width - 110,0,100,40), boxstyle);
			GUILayout.Label( p2Name + "\r\n" + p2.Score.ToString() );
			GUILayout.EndArea ();
		}

		if(currentPlayers.Count > 2)
		{
			DudeController p3 = currentPlayers [2].GetComponent<DudeController> ();

			Color purple = new Color(0.8f, 0.1f, 0.8f, 1f);
			DrawRectangle (new Rect (0, Screen.height - 40, 10, 40), purple);
			
			GUILayout.BeginArea (new Rect (10, Screen.height - 40,100,40), boxstyle);
			GUILayout.Label( p3Name + "\r\n" + p3.Score.ToString() );
			GUILayout.EndArea ();
		}

		if(currentPlayers.Count > 3)
		{
			DudeController p4 = currentPlayers [3].GetComponent<DudeController> ();

			DrawRectangle (new Rect (Screen.width - 10, Screen.height - 40, 10, 40), Color.cyan);
			
			GUILayout.BeginArea (new Rect (Screen.width - 110, Screen.height - 40, 100, 40), boxstyle);
			GUILayout.Label( p4Name + "\r\n" + p4.Score.ToString() );
			GUILayout.EndArea ();
		}
	}



	void DrawRectangle (Rect position, Color color)
	{
		Texture2D texture = MakeTexture (color);
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}

	Texture2D MakeTexture (Color color)
	{
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();

		return texture;
	}
}
