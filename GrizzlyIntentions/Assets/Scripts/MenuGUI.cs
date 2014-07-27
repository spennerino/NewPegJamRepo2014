using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	public string p1Name = "Player 1";
	private bool p1Playing = true;

	private string p2Name = "Player 2";
	private bool p2Playing = true;

	private string p3Name = "Player 3";
	private bool p3Playing = true;

	private string p4Name = "Player 4";
	private bool p4Playing = true;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI ()
	{
		GUIStyle style = new GUIStyle ();
		style.alignment = UnityEngine.TextAnchor.MiddleCenter;
		style.normal.textColor = Color.black;


		GUILayout.BeginArea (new Rect (Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.height / 2));

		GUILayout.BeginHorizontal();

		p1Name = GUILayout.TextField (p1Name);
		p1Playing = GUILayout.Toggle (p1Playing, "Is Playing?");

		p2Name = GUILayout.TextField (p2Name);
		p2Playing = GUILayout.Toggle (p2Playing, "Is Playing?");

		GUILayout.EndHorizontal ();

		GUILayout.Space (30);

		GUILayout.BeginHorizontal ();

		p3Name = GUILayout.TextField (p3Name);
		p3Playing = GUILayout.Toggle (p3Playing, "Is Playing?");

		p4Name = GUILayout.TextField (p4Name);
		p4Playing = GUILayout.Toggle (p4Playing, "Is Playing?");

		GUILayout.EndHorizontal();

		GUILayout.EndArea ();
	}
}
