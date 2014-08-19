using UnityEngine;
using System.Collections;

public class GUIAspectRatioScale : MonoBehaviour 
{
	public Vector2 scaleOnRatio;
	private float widthHeightRatio;

	void Start () {
		SetScale();
	}

	void Update (){

	}

	void SetScale (){
		//find the aspect ratio
		widthHeightRatio = (float) Screen.width / Screen.height ;

		//Apply the scale. We only calculate y since our aspect ratio is x (width) authoritative: width/height (x/y)
		transform.localScale = new Vector3 (scaleOnRatio.x, widthHeightRatio * scaleOnRatio.y, 1);
	}
}