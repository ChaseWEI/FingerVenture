using UnityEngine;
using System.Collections;

public class InstantiateNum : MonoBehaviour {

	public GameObject num1;
	public GameObject num2;
	public GameObject num3;
	public GameObject num4;
	public GameObject num5;
	public GameObject num6;
	public GameObject num7;
	public Camera mainCam;
	
	void Start () {

		int randX0 = Random.Range(-7,7);
		int randY0 =Random.Range(-3,3);
		int randX1 = Random.Range(-7,7);
		int randY1 =Random.Range(-3,3);
		int randX2 = Random.Range(-7,7);
		int randY2 =Random.Range(-3,3);
		int randX3 = Random.Range(-7,7);
		int randY3 =Random.Range(-3,3);
		int randX4 = Random.Range(-7,7);
		int randY4 =Random.Range(-3,3);
		int randX5 = Random.Range(-7,7);
		int randY5 =Random.Range(-3,3);
		int randX6 = Random.Range(-7,7);
		int randY6 =Random.Range(-3,3);

		Instantiate ( num1, new Vector2(randX0, randY0),Quaternion.identity);
		Instantiate ( num2, new Vector2(randX1, randY1),Quaternion.identity);
		Instantiate ( num3, new Vector2(randX2, randY2),Quaternion.identity);
		if(Variable.level >= 2){
			Instantiate ( num4, new Vector2(randX3, randY3),Quaternion.identity);
			Instantiate ( num5, new Vector2(randX4, randY4),Quaternion.identity);
			if(Variable.level == 3){
				Instantiate ( num6, new Vector2(randX5, randY5),Quaternion.identity);
				Instantiate ( num7, new Vector2(randX6, randY6),Quaternion.identity);
			}
		}
	}

}