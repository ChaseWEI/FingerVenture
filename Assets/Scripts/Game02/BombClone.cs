using UnityEngine;
using System.Collections;

public class BombClone : MonoBehaviour {
	public GameObject bombPrefab;
	public Camera mainCam;
	private float nextSpawnTime;
	private int [] bombPosNum = new int[6];

	void Start () {
		for(int i = 0; i < 6; i++)
			bombPosNum[i] = i + 1;
		StartCoroutine (InstantiateBombs (-1));
	}

	void Poker(){
		for(int i = 0; i < 6; i++) {
			int j = Random.Range(0, 6);
			int k = Random.Range(0, 6);
			int temp = bombPosNum[j];
			bombPosNum[j] = bombPosNum[k];
			bombPosNum[k] = temp;
		}
	}
		
		
	IEnumerator InstantiateBombs(int index){
		yield return new WaitForSeconds(0.5f);
		if (!Variable.isTimeToNext){
			float bombPos = Screen.width / 6;
			index = (index + 1) % 6;

			if (index == 0)
				Poker ();

			Instantiate(bombPrefab, new Vector3(mainCam.ScreenToWorldPoint(new Vector3(bombPos * bombPosNum[index]	- bombPos /2, 0, 0)).x,
			                                    mainCam.ScreenToWorldPoint(new Vector3(0, Screen.height + 64, 0)).y, 0), Quaternion.identity);
			StartCoroutine(InstantiateBombs(index));
		}
	}


}
