using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	
	public GUIStyle [] buttonStyle;
	private float buttonSizeW;
	private float buttonSizeH;
	private float smallButtonSizeW;
	private float smallButtonSizeH;
	private float widthHeightRatio;

	public GameObject shared;

	void Start () {
		widthHeightRatio = (float)Screen.width / Screen.height;
		buttonSizeW = Screen.width * 880f / 1920f;
		buttonSizeH = Screen.height * 270f / 1920f * widthHeightRatio;
		smallButtonSizeW = Screen.width * 200f / 1920f;
		smallButtonSizeH = Screen.height * 200f / 1920f * widthHeightRatio;
	}

	void Awake(){
		DontDestroyOnLoad (shared);
	}

	void Update(){

	}

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 50f, Screen.height / 3f, 
		                          buttonSizeW, buttonSizeH), "", buttonStyle[0])) {
			Variable.score = 0;
			Application.LoadLevel("Loading");
		}
		if (GUI.Button (new Rect (Screen.width / 50f, Screen.height / 3f * 1.6f, 
		                          buttonSizeW , buttonSizeH), "", buttonStyle[1])) {
			Application.LoadLevel("Ranking");
		}
		if (GUI.Button (new Rect (Screen.width / 50f, Screen.height / 3f * 2.2f, 
		                          buttonSizeW, buttonSizeH), "", buttonStyle[2])) {
			Application.LoadLevel("Collection");
		}	
		if (GUI.Button (new Rect (Screen.width - (2 * Screen.width / 10f), Screen.height / 50f, 
		                          smallButtonSizeW, smallButtonSizeH), "", buttonStyle[3])) {
			//StartCoroutine(Facebook());
			print ("Facebook");
		}
		if (GUI.Button (new Rect (Screen.width - (Screen.width / 10f), Screen.height / 50f, 
		                          smallButtonSizeW, smallButtonSizeH), "", buttonStyle[4])) {
			//StartCoroutine(Setting());
			print ("Setting");
		}
	}

}
