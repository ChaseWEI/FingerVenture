using UnityEngine;
using System.Collections;

public class TimerScripts : MonoBehaviour {

	public GUISkin theSkin;
	private float startTime;
	private float curTime;
	private float tmpTime;
	private float gameTime;

	void Awake () {
		//For Test
		//Variable.level = 3;
	}

	void Start () {

		startTime = Time.time;
		curTime = Time.time;
		gameTime = Method.GetGameTime ();
		tmpTime = gameTime;
	}
	
	void Update () {
		curTime = Time.time;
	}
	
	void OnGUI (){
		GUI.skin = theSkin;
		tmpTime = gameTime - (curTime - startTime);
		if(tmpTime >= 0 && !Variable.isTimeToNext)
			GUI.HorizontalScrollbar(new Rect (0, 0, Screen.width, 30), gameTime, tmpTime, 0.0f, gameTime, theSkin.GetStyle("horizontalScrollbar"));
		else
			Variable.isTimeToNext = true;
	}
}
