using UnityEngine;
using System.Collections;

public class TransitionGUI : MonoBehaviour {

	public GUIStyle labelStyle;

	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 2f - (Screen.width / 3f / 2f), Screen.height / 2f - (Screen.height / 3f / 2f),
		                     Screen.width / 3f, Screen.height / 3f), "" + Variable.score, labelStyle);
	}
}
