using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGUI : MonoBehaviour {

	private List<GameObject> 	currentPlayers;

	public string p1Name, p2Name, p3Name, p4Name;
	private bool p1Playing, p2Playing, p3Playing, p4Playing;

	private int GUIBoxWidth = 200;
	private int GUIBoxHeight = 45;

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

		GUIStyle ltext = new GUIStyle ();
		GUIStyle rtext = new GUIStyle ();
		ltext.alignment = UnityEngine.TextAnchor.MiddleLeft;
		ltext.normal.textColor = Color.white;
		ltext.padding = new RectOffset (10, 0, 5, 0);
		rtext.alignment = UnityEngine.TextAnchor.MiddleRight;
		rtext.normal.textColor = Color.white;
		rtext.padding = new RectOffset (0, 10, 5, 0);


		DrawRectangle (new Rect (0, 0, 10, GUIBoxHeight), Color.red);

		GUILayout.BeginArea (new Rect (10, 0, GUIBoxWidth, GUIBoxHeight), boxstyle);
		GUILayout.Label( p1Name + "\r\n" + p1.Score.ToString(), ltext, null );
		GUILayout.EndArea ();


		if(currentPlayers.Count > 1)
		{
			DudeController p2 = currentPlayers [1].GetComponent<DudeController> ();

			DrawRectangle (new Rect (Screen.width - 10, 0, 10, GUIBoxHeight), Color.yellow);
			
			GUILayout.BeginArea (new Rect (Screen.width - (GUIBoxWidth + 10), 0, GUIBoxWidth, GUIBoxHeight), boxstyle);
			GUILayout.Label( p2Name + "\r\n" + p2.Score.ToString(), rtext, null );
			GUILayout.EndArea ();
		}

		if(currentPlayers.Count > 2)
		{
			DudeController p3 = currentPlayers [2].GetComponent<DudeController> ();

			Color purple = new Color(0.8f, 0.1f, 0.8f, 1f);
			DrawRectangle (new Rect (0, Screen.height - GUIBoxHeight, 10, GUIBoxHeight), purple);
			
			GUILayout.BeginArea (new Rect (10, Screen.height - GUIBoxHeight, GUIBoxWidth, GUIBoxHeight), boxstyle);
			GUILayout.Label( p3Name + "\r\n" + p3.Score.ToString(), ltext, null );
			GUILayout.EndArea ();
		}

		if(currentPlayers.Count > 3)
		{
			DudeController p4 = currentPlayers [3].GetComponent<DudeController> ();

			DrawRectangle (new Rect (Screen.width - 10, Screen.height - GUIBoxHeight, 10, GUIBoxHeight), Color.cyan);
			
			GUILayout.BeginArea (new Rect (Screen.width - (GUIBoxWidth + 10), Screen.height - GUIBoxHeight, GUIBoxWidth, GUIBoxHeight), boxstyle);
			GUILayout.Label( p4Name + "\r\n" + p4.Score.ToString(), rtext, null );
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
