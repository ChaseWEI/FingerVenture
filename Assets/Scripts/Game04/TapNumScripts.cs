using UnityEngine;
using System.Collections;

public class TapNumScripts: MonoBehaviour {

	void OnTap(TapGesture gesture) { 
		if (Time.timeScale != 0){
			int num = int.Parse(gameObject.name.Substring (3, 1));

			if (num == 1)
				Destroy(gesture.Selection.gameObject);
			else if (GameObject.Find ("Num" + (num-1) + "(Clone)") == null){
				Destroy(gesture.Selection.gameObject);
				if (GameObject.Find ("Num" + (num+1) + "(Clone)") == null)
					Variable.isPass = true;
			}
		}

	}
}
