using UnityEngine;
using System.Collections;

public class Count: MonoBehaviour {
	public static int count ;

	void Awake () {
		count = 0;
	}

	void OnGUI(){
		int a = InstantiateGopher.total- count;
		if (a >= 0)
			guiText.text = "" + a;
		else
			guiText.text = "" + 0;
		if ( a ==0 )
			Variable.isPass = true;
	}
}
