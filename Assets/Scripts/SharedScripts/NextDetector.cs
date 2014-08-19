using UnityEngine;
using System.Collections;

public class NextDetector : MonoBehaviour {

	void Update () {
		if (Variable.isTimeToNext || Variable.isPass)
			StartCoroutine(Transition());
	}
	
	IEnumerator Transition(){
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel("Transition");
	}
}
