using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderboardGUI : MonoBehaviour {

	private string name;
	private int score;

	private List<int> previousHighScores;
	private int maxScores = 5;

	void Start()
	{
		previousHighScores = new List<int>();

		for(int i = 0; i < maxScores; i++)
		{
			int tmp = PlayerPrefs.GetInt("Highscore" + i.ToString());
			previousHighScores.Add(tmp);
		}
		
		bool isHighScore = false;

		int lastManStandingScore = PlayerPrefs.GetInt ("LastHighscore");

		for (int i = 0; i < maxScores; i++)
		{
			if(lastManStandingScore > previousHighScores[i] && !isHighScore)
			{
				previousHighScores.Insert(i, lastManStandingScore);
				isHighScore = true;
			}
		}
		
		if(isHighScore)
		{
			for (int i = 0; i < maxScores; i++)
			{
				PlayerPrefs.SetInt("Highscore" + i.ToString(), previousHighScores[i]);
			}
		}

		PlayerPrefs.Save ();

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

		GUILayout.EndArea ();
	}
}
