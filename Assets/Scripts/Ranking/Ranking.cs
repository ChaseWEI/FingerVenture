using UnityEngine;
using System.Collections;

public class Ranking : MonoBehaviour {

	public static bool isPersonal;
	public Sprite personal;
	public Sprite facebook;
	public GUIStyle backButton;

	void Start () {
		isPersonal = true;
	}

	void Update () {
		if (isPersonal) {
			GetComponent<SpriteRenderer>().sprite = personal; 

		}
		else {
			GetComponent<SpriteRenderer>().sprite = facebook;

		}

	}

	void OnGUI () {
		if (GUI.Button (new Rect (10, 10, Screen.width * 0.067f, Screen.height * 0.12f), "", backButton)) {
			Application.LoadLevel("Menu");
		}
	}
}
