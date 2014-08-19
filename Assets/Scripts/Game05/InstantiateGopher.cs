using UnityEngine;
using System.Collections;

public class InstantiateGopher : MonoBehaviour {

	public GameObject Gopher;
	public static int total;
	public static float[,] array1 = new float[,] {  { -1.6f, -0.08226755f ,0 }, 
													{ 1.35f, -0.416029f ,0}, { 4.3f, -0.1209209f ,0},
													{ -3.5f, -1.825992f ,0}, { -0.67f, -1.366934f ,0}, 
													{ 3.2f, -1.530883f ,0},{ -2.9f, -3.301534f ,0}, 
													{ -0.15f, -2.940846f ,0},{ 2.37151f, -3.465483f ,0} };
	
	void Start () {
		if(Variable.level==1)total=5;
		if(Variable.level==2)total=7;
		if(Variable.level==3)total=9;

		InvokeRepeating("Timer",0.5f,0.8f);
		InvokeRepeating("Timer",0.8f,0.8f);
	}

	void Timer(){
		int rand = Random.Range(0,9);
		if(array1[rand,2]==0){
			if(rand<=2){
				Instantiate ( Gopher, new Vector3(array1[rand,0], array1[rand,1],-1),Quaternion.identity);
				array1[rand,2]=1;
			}
			else if(rand<=5 && rand>2){
				Instantiate ( Gopher, new Vector3(array1[rand,0], array1[rand,1],-3),Quaternion.identity);
				array1[rand,2]=1;
			}
			else if( rand>5){
				Instantiate ( Gopher, new Vector3(array1[rand,0], array1[rand,1],-5),Quaternion.identity);
				array1[rand,2]=1;
			}
		}else 
			Timer();
	}
}
