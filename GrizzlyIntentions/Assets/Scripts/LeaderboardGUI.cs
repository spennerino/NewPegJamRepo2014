using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderboardGUI : MonoBehaviour {

	private List<int> previousHighScores;
	private List<string> previousHighScoreNames;
	private int maxScores = 5;

	void Start()
	{
		Screen.showCursor = true;

		previousHighScores = new List<int>();
		previousHighScoreNames = new List<string> ();

		for(int i = 0; i < maxScores; i++)
		{
			int tmpscore   = PlayerPrefs.GetInt("Highscore" + i.ToString());
			string tmpname = PlayerPrefs.GetString ("HighscoreBy" + i.ToString());

			previousHighScores.Add(tmpscore);
			previousHighScoreNames.Add (tmpname);
		}

		for(int i = 0; i < 4; i++)
		{
			int tmpScore =   PlayerPrefs.GetInt ("P" + (i+1).ToString() + "Score");
			string tmpName = PlayerPrefs.GetString ("P" + (i+1).ToString() + "Name");


			Debug.Log("P" + (i+1).ToString()  + "Score = " + tmpScore.ToString());


			bool isHighScore = false;

			for (int j = 0; j < maxScores; j++)
			{
				if(tmpScore > previousHighScores[j] && !isHighScore)
				{
					previousHighScores.Insert(j, tmpScore);
					previousHighScoreNames.Insert(j, tmpName);

					isHighScore = true;
				}
			}
			
			if(isHighScore)
			{
				for (int j = 0; j < maxScores; j++)
				{
					PlayerPrefs.SetInt("Highscore" + j.ToString(), previousHighScores[j]);
					PlayerPrefs.SetString("HighscoreBy" + j.ToString(), previousHighScoreNames[j]);
				}
			}

			PlayerPrefs.Save ();
		}

	}
	
	
	void OnGUI ()
	{
		float colWidth = Screen.width / 4;

		GUILayoutOption[] layoutParams = { GUILayout.Width(colWidth) };
		GUIStyle style = new GUIStyle ();
		style.alignment = UnityEngine.TextAnchor.MiddleCenter;
		style.normal.textColor = Color.white;

		GUILayout.BeginArea (new Rect (Screen.width / 4, Screen.height - 175, colWidth * 2, 175));

		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Leaderboard:", style, GUILayout.Width(colWidth * 2));
		GUILayout.EndHorizontal();

		GUILayout.Space(10);

		for(int i = 0; i < maxScores; i++)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(previousHighScoreNames[i], style, layoutParams);
			GUILayout.Label(previousHighScores[i].ToString(), style, layoutParams);
			GUILayout.EndHorizontal();
		}

		GUILayout.Space (5);

		if(GUILayout.Button("Restart Game"))
		{
			AutoFade.LoadLevel("MainScene", 0.5f, 0.5f, Color.black);
		}

		GUILayout.Space (5);

		if(GUILayout.Button("End Game"))
		{
			Application.Quit ();
		}

		GUILayout.EndArea ();
	}
}
