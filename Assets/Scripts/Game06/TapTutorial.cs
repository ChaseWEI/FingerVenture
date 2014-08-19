using UnityEngine;
using System.Collections;

public class TapTutorial : MonoBehaviour {
	public static int count;
	public GameObject Bubble;
	public GameObject Broke;
	public int[] array2;
	public float[,] array1 = new float[18,2]{ { -7.448695f, 1.25809f }, {-5.57154f, 1.25809f}, { -3.534636f, 1.25809f}, { -1.497725f, 1.058393f}, { 0.2995459f,0.8586959f}, { 2.256575f, 0.7388783f }, { -7.328875f,-0.9385762f}, { -5.571538f, -0.9385755f}, {-3.614512f, -0.9785149f}, { -1.617544f, -1.098333f }, { 0.3794241f, -1.178212f}, { 2.216635f, -1.337968f}, { -7.328874f, -2.975482f}, { -5.5316f,-2.895603f}, { -3.534633f, -3.015421f}, { -1.577605f, -3.015422f}, {0.1797271f, -3.215119f}, { 2.056878f, -3.414815f} };
	int i = 18;

	void Awake () {
		count = 0;
	}
	
	// Use this for initialization
	void Start () {

		if(Variable.level == 1) array2 = new int[]{1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		if(Variable.level == 2) array2 = new int[]{1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0};
		if(Variable.level == 3) array2 = new int[]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0};

		for(int x = 0 ; x < i ; i--) {
			int j = Random.Range(0,i);
			int k = Random.Range(0,i);
			int temp = array2[j];
			array2[j] = array2[k];
			array2[k] = temp;
		}

		for(int j = 0 ; j<18 ; j++){
			if(array2[j]==0)Instantiate ( Broke, new Vector2(array1[j,0], array1[j,1]),Quaternion.identity);

			if(array2[j]==1)Instantiate ( Bubble, new Vector2(array1[j,0], array1[j,1]),Quaternion.identity);

		}

	}

	// Update is called once per frame
	void Update () {
		switch (Variable.level){
		case 1:
			if (count == 4) 
				Variable.isPass = true;
			break;
		case 2:
			if (count == 8) 
				Variable.isPass = true;
			break;
		case 3:
			if (count == 16) 
				Variable.isPass = true;
			break;
		default:
			break;
			
		}

	}
	
}

