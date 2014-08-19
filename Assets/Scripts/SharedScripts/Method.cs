using UnityEngine;
using System.Collections;

public class Method : MonoBehaviour {

	public static int GetGameTime(){
		switch(Variable.level){
		case 1:
			return 5;
		case 2:
			return 4;
		case 3:
			return 3;
		default:
			return 0;
		}

	}
}
