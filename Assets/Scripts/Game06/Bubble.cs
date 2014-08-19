using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	int index = 1;
	public Sprite spriteImage;

	void OnTap(TapGesture gesture) { 
		if (Time.timeScale != 0){
			if (gesture.Selection && index == 1) {
				index = 2;
				GetComponent<SpriteRenderer>().sprite = spriteImage;
				TapTutorial.count +=1;
			}
		}
	}
}
