using UnityEngine;
using System.Collections;

public class SetGameArray : MonoBehaviour {
	
	void Awake () {
		for(int i = 0; i < Variable.gameNum; i++)
			Variable.gameArray[i] = i + 1;

		Variable.gameArray = new int[]{6, 5, 3, 2, 1, 4};
		//RandGameArray ();
	}

	void Update () {
	
	}

	void RandGameArray() {
		for(int i = 0; i < Variable.gameNum; i++){
			int j = Random.Range(0, Variable.gameNum);
			int k = Random.Range(0, Variable.gameNum);
			int temp = Variable.gameArray[j];
			Variable.gameArray[j] = Variable.gameArray[k];
			Variable.gameArray[k] = temp;
		}
	}
}
