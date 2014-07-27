using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderboardGUI : MonoBehaviour {

	private string name;
	private int score;

	private List<int> previousHighScores;
	private List<int> newHighScores;
	private int maxScores = 5;

	void Start()
	{
		previousHighScores = new List<int>();
		newHighScores = new List<int> ();

		List<GameObject> players = PlayerUtil.GetPlayers ();

		for(int i = 0; i < maxScores; i++)
		{
			int tmp = PlayerPrefs.GetInt("Highscore" + i.ToString());
			previousHighScores.Add(tmp);
		}

		for(int i = 0; i < players.Count; i++)
		{
			DudeController dc = players[i].GetComponent<DudeController>();

			int tmpScore = PlayerPrefs.GetInt ("P" + (i+1).ToString() + "Score", dc.Score);

			bool isHighScore = false;

			for (int j = 0; j < maxScores; j++)
			{
				if(tmpScore > previousHighScores[j] && !isHighScore)
				{
					previousHighScores.Insert(j, tmpScore);
					isHighScore = true;
				}
			}
			
			if(isHighScore)
			{
				for (int j = 0; j < maxScores; j++)
				{
					PlayerPrefs.SetInt("Highscore" + j.ToString(), previousHighScores[j]);
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

		GUILayout.BeginArea (new Rect (Screen.width / 4, Screen.height - 150, colWidth * 2, 150));

		GUILayout.BeginHorizontal();
		GUILayout.Label("Name", style, layoutParams );
		GUILayout.Label("Scores", style, layoutParams );
		GUILayout.EndHorizontal();

		GUILayout.Space(25);

		foreach(int score in previousHighScores)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("", style, layoutParams);
			GUILayout.Label(score.ToString(), style, layoutParams);
			GUILayout.EndHorizontal();
		}

		GUILayout.Space (10);

		if(GUILayout.Button("Restart Game"))
		{
			AutoFade.LoadLevel("MainScene", 0.5f, 0.5f, Color.black);
		}

		GUILayout.EndArea ();
	}
}
