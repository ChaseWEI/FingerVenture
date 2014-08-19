using UnityEngine;
using System.Collections;

public class LoadGestures : MonoBehaviour {
	void Start () {
		LoadingScripts.isLoadGesture = true;
		StartCoroutine (LoadingScripts.LoadGame(1f));
	}
}
