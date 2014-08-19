using UnityEngine;
using System.Collections;

public class ChangeRanking : MonoBehaviour {
	public GameObject personal;
	public GameObject facebook;
	void Start () {

	}
	

	void Update () {
	
	}

	void OnTap (TapGesture gesture) {
		print (name);
		if (name == "Personal(Clone)") {
			Ranking.isPersonal = true;
			Destroy(gameObject);
			Instantiate(facebook);
		}
		else {
			Ranking.isPersonal = false;
			Destroy(gameObject);
			Instantiate(personal);
		}
	}
}
