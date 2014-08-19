using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public GUISkin pauseSkin;


	private bool isPause;
	private bool musicOn;
	private Rect pausebButtonRect;
	private Rect blackRect;
	private Rect boxRect;
	private Rect labelRect;
	private Rect scoreRect;
	private float button1PosX;
	private float button2PosX;
	private float button3PosX;
	private float buttonPosY;
	private Vector2 buttonSize;

	void Start () {
		isPause = false;
		musicOn = true;

		float widthHeightRatio = (float)Screen.width / Screen.height;
		pausebButtonRect = new Rect (Screen.width - (Screen.width / 10), Screen.height / 50,
		                             Screen.width * 150 / 1920, Screen.height * 150 / 1920 * widthHeightRatio);
		labelRect = new Rect (Screen.width * 1.5f / 10 + Screen.width * 0.07f, Screen.height * 1.5f / 10 + Screen.height * 0.14f,
		                      Screen.width * 0.252f, Screen.height * 0.114f);
		scoreRect = new Rect (Screen.width * 1.5f / 10 + Screen.width * 0.322f, Screen.height * 1.5f / 10 + Screen.height * 0.14f,
		                      Screen.width * 0.252f, Screen.height * 0.114f);
		blackRect = new Rect (0 - 10, 0 - 10, Screen.width + 20, Screen.height + 20);
		boxRect = new Rect (Screen.width * 1.5f / 10, Screen.height * 1.5f / 10, Screen.width * 7 / 10, Screen.height * 7 / 10);
		button1PosX = Screen.width * 1.5f / 10 + Screen.width * 7 / 120;
		button2PosX = Screen.width * 1.5f / 10 + Screen.width * 35 / 120;
		button3PosX = Screen.width * 1.5f / 10 + Screen.width * 63 / 120;
		buttonPosY = Screen.height / 1.65f;
		buttonSize = new Vector2 (Screen.width * 21 / 200, Screen.height * 21 / 200 * widthHeightRatio);
	}

	void Update() {
		if (isPause)
			Time.timeScale = 0.0f;
		else
			Time.timeScale = 1.0f;
	}		

	void OnGUI () {
		GUI.skin = pauseSkin;

		if (!isPause){
			if (GUI.Button (pausebButtonRect, "", "Pause")) {
				isPause = true;
			}
		}

		if (isPause) {
			//Color tempColoer = GUI.color;

			//GUI.color = new Color(0, 0, 0);
				
			GUI.Box (blackRect, "");

			//GUI.color = tempColoer;

			GUI.Box (boxRect, "", "PauseBox");

			//pauseBox.transform.localScale = new Vector3 (0.7f, 0.7f, 0);

			GUI.Label(labelRect, "", "ScoreLabel");

			GUI.Label(scoreRect, "" + Variable.score, "Score");



			if (GUI.Button (new Rect (button1PosX, buttonPosY, buttonSize.x, buttonSize.y), "", "BackToMenu")) {
				isPause = false;
				Application.LoadLevel("Menu");
			}

			if (GUI.Button (new Rect (button2PosX, buttonPosY, buttonSize.x, buttonSize.y), "", "Continue")) {
				isPause = false;
			}

			if(musicOn){
				if (GUI.Button (new Rect (button3PosX, buttonPosY, buttonSize.x, buttonSize.y), "", "MusicOn")) {
					musicOn = false;
				}
			}

			else{
				if (GUI.Button (new Rect (button3PosX, buttonPosY, buttonSize.x, buttonSize.y), "", "MusicOff")) {
					musicOn = true;
				}
			}

			//if (GUI.Button (pausebButtonRect, "", "Continue")) {
			//	isPause = false;
			//}
		}

	}
}
