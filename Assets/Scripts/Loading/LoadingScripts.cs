using UnityEngine;
using System.Collections;

public class LoadingScripts : MonoBehaviour {
	public static bool isLoadGesture = false;

	void Start () {
		StartCoroutine (LoadGame (3f));
	}

	public static IEnumerator LoadGame(float delay){

		int temp = Variable.gameArray[Variable.stageCount % Variable.gameNum];


		if (Variable.level != 1 || isLoadGesture) {
			string gameName;
			if(Variable.gameArray[0] < 10)
				gameName = "Game0" + temp;
			else
				gameName = "Game" + temp;

			AsyncOperation async = Application.LoadLevelAsync (gameName);
			async.allowSceneActivation = false;
			yield return new WaitForSeconds (delay);
			async.allowSceneActivation = true;
		}
		else {
			yield return new WaitForSeconds (delay);
			switch (temp) {
				case 1:
					Application.LoadLevel ("Rotate");
					break;
				case 2:
					Application.LoadLevel ("Rotate");
					break;
				case 3:
					Application.LoadLevel ("SwipeRight");
					break;
				case 4:
					Application.LoadLevel ("Tap");
					break;
				case 5:
					Application.LoadLevel ("Tap");
					break;
				case 6:
					Application.LoadLevel ("Tap");
					break;
				default:
					break;
			}
		}
	}
}
