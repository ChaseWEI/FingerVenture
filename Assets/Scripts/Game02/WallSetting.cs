using UnityEngine;
using System.Collections;

public class WallSetting : MonoBehaviour {
	public GameObject leftWall;
	public GameObject rightWall;
	public GameObject ground;

	public Camera mainCam;
	// Use this for initialization
	void Start () {
		leftWall.transform.localScale = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);;
		leftWall.transform.position = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.transform.localScale = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);;
		rightWall.transform.position = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

		ground.transform.localScale = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.width * 2f, 0f)).y, 1f);;
		ground.transform.position = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);
	}
}