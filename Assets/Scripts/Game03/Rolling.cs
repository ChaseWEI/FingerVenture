using UnityEngine;
using System.Collections;

public class Rolling : MonoBehaviour {
	private Animator anim;
	public static float count = 0;

	void Awake () {
		count = 0;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Count", count);
	}
}
