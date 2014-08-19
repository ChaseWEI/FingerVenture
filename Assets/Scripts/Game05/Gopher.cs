using UnityEngine;
using System.Collections;

public class Gopher : MonoBehaviour {

	float x ;
	float y ;
	float curTime;
	float lerp;
	float Down;


	void Awake () {
	
	}
	void OnTap(TapGesture gesture) {
		if (Time.timeScale != 0) {
			if (gesture.Selection.name == "Gopher(Clone)"){
				Debug.Log(gesture.Selection.name);
				Destroy(gesture.Selection.gameObject);
				Count.count+=1;
				//Debug.Log(SCORE.Count);
				if(x == -1.6f && y== -0.08226755f ){InstantiateGopher.array1[0,2]=0;}
				if(x == 1.35f && y==-0.416029f ){InstantiateGopher.array1[1,2]=0;}
				if(x == 4.3f && y==-0.1209209f ){InstantiateGopher.array1[2,2]=0;}
				if(x == -3.5f && y==-1.825992f ){InstantiateGopher.array1[3,2]=0;}
				if(x ==  -0.67f && y==-1.366934f ){InstantiateGopher.array1[4,2]=0;}
				if(x == 3.2f && y==-1.530883f ){InstantiateGopher.array1[5,2]=0;}
				if(x == -2.9f && y==-3.301534f ){InstantiateGopher.array1[6,2]=0;}
				if(x == -0.15f && y==-2.940846f ){InstantiateGopher.array1[7,2]=0;}
				if(x == 2.37151f && y==-3.465483f ){InstantiateGopher.array1[8,2]=0;}

			}
		}
	}
	void Start () {
		lerp = 0;
		Down = 0;
		curTime = Time.time;
		x = transform.position.x;
	 	y = transform.position.y;
	}



	// Update is called once per frame
	void FixedUpdate () {
		lerp += 0.1f;
		transform.position = Vector3.Lerp (new Vector3 (x, y, transform.position.z), new Vector3 (x, y + 2, transform.position.z), lerp);

 
		if ((Time.time - curTime) >= 1) {
			Down += 0.1f;
			transform.position = Vector3.Lerp (new Vector3 (x, y + 2, transform.position.z), new Vector3 (x, y, transform.position.z), Down);
		}
		if((Time.time - curTime) >= 1.3){
			if(x == -1.6f && y== -0.08226755f ){InstantiateGopher.array1[0,2]=0;}
			if(x == 1.35f && y==-0.416029f ){InstantiateGopher.array1[1,2]=0;}
			if(x == 4.3f && y==-0.1209209f ){InstantiateGopher.array1[2,2]=0;}
			if(x == -3.5f && y==-1.825992f ){InstantiateGopher.array1[3,2]=0;}
			if(x ==  -0.67f && y==-1.366934f ){InstantiateGopher.array1[4,2]=0;}
			if(x == 3.2f && y==-1.530883f ){InstantiateGopher.array1[5,2]=0;}
			if(x == -2.9f && y==-3.301534f ){InstantiateGopher.array1[6,2]=0;}
			if(x == -0.15f && y==-2.940846f ){InstantiateGopher.array1[7,2]=0;}
			if(x == 2.37151f && y==-3.465483f ){InstantiateGopher.array1[8,2]=0;}

			Destroy(gameObject);
		}
		
	}
}