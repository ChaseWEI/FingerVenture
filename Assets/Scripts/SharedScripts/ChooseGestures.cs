using UnityEngine;
using System.Collections;

public class ChooseGestures : MonoBehaviour {
	
	void Start () {
		int temp = Variable.gameArray [Variable.stageCount % Variable.gameNum];
		switch (temp){
			case 1:
				StartCoroutine (LoadGesture("Rotate"));
				break;
			case 2:
				StartCoroutine (LoadGesture("Rotate"));
				break;
			case 3:
				StartCoroutine (LoadGesture("SwipeRight"));
				break;
			case 4:
				StartCoroutine (LoadGesture("Tap"));
				break;
			case 5:
				StartCoroutine (LoadGesture("Tap"));
				break;
			case 6:
				StartCoroutine (LoadGesture("Tap"));
				break;

		}
	}

	IEnumerator LoadGesture (string name) {
		AsyncOperation async = Application.LoadLevelAsync(name);
		async.allowSceneActivation = false;
		yield return new WaitForSeconds (3f);
		async.allowSceneActivation = true;
	}
}
