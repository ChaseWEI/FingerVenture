using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {

	public GameObject lifePrefab;
	public GameObject failPrefab;

	void Start () {
		//For Test
		//Variable.life = 1;
		//print ("Level: " + Variable.level);	

		LoadingScripts.isLoadGesture = false;

		if (Variable.isPass ) {
			Variable.score += 100;
			Variable.isPass = false;
		}
		else {
			if (Variable.life > 0){
				if(--Variable.life == 0)
					StartCoroutine( GameOver());
				Instantiate(failPrefab, new Vector3(-3.3f + 3.3f * (3 - (Variable.life + 1)), -3f, 0), Quaternion.identity);
			}
		}

		Variable.isTimeToNext = false;
		Variable.stageCount += 1;

		if (Variable.stageCount % Variable.gameNum == 0 && Variable.level != 3)
			Variable.level += 1;

		if (Variable.life > 0)
			StartCoroutine (WaitForNext());

		InstantiatePrefab ();
	} 

	IEnumerator WaitForNext () {
		yield return new WaitForSeconds (3f);
		StartCoroutine(LoadingScripts.LoadGame(0f));
	}

	IEnumerator GameOver(){
		yield return new WaitForSeconds (3f);
		Application.LoadLevel("GameOver");
	}

	void InstantiatePrefab() {
		for(int i = 0; i < Variable.life; i++)
			Instantiate(lifePrefab, new Vector3(-3.3f + 3.3f * (2 - i), -3f, 0), Quaternion.identity);
	}
}
