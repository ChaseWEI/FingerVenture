using UnityEngine;
using System.Collections;

public class DestroyBombs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collInfo){
		if(collInfo.gameObject.tag == "Ground")
			Destroy(gameObject);
	}
}
