using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	void Start () {
		StartCoroutine (WaitForNext ());
	}

	IEnumerator WaitForNext () {
		AsyncOperation async = Application.LoadLevelAsync ("Menu");
		async.allowSceneActivation = false;
		yield return new WaitForSeconds (3f);
		async.allowSceneActivation = true;
	}

}
