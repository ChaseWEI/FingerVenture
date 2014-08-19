using UnityEngine;
using System.Collections;

public class Collection : MonoBehaviour {

	public GUIStyle backButton;

	void OnGUI () {
		if (GUI.Button (new Rect (10, 10, Screen.width * 0.067f, Screen.height * 0.12f), "", backButton)) {
			Application.LoadLevel("Menu");
		}
	}
}
