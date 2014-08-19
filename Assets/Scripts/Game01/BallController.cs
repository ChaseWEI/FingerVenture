using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float speed;
	private bool isGrounded;

	void Start () {

	}

	void Update () {
	
	}

	void FixedUpdate(){
		if(!isGrounded){
			rigidbody2D.velocity += new Vector2 (Input.acceleration.x * speed * Time.deltaTime,
			                                     Input.acceleration.y * speed * Time.deltaTime);
		}
		else{
			rigidbody2D.velocity += new Vector2 (-0.05f, -0.05f);
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		if (collider.collider.tag == "Ground") {
			StartCoroutine(Wait());
			if(!Variable.isTimeToNext)
				Variable.isPass = true;
			isGrounded = true;
		}
	}

	IEnumerator  Wait(){
		yield return new WaitForSeconds (2);
	}


}
