using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator anim;
	private float maxSpeed;
	private bool facingRight;
	private float startTime;
	private float curTime;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
		anim = GetComponent<Animator>();
		maxSpeed = 15f;
		facingRight = false;
	}

	void Update(){
		curTime = Time.time;
		if (curTime - startTime >= Method.GetGameTime () && !Variable.isTimeToNext)
			Variable.isPass = true;
	}

	void FixedUpdate () {
		if (!anim.GetBool("isHit")){
			float speed;
			speed = Input.acceleration.x;
			anim.SetFloat("speed", Mathf.Abs(speed));
			rigidbody2D.velocity = new Vector2 (speed * maxSpeed, rigidbody2D.velocity.y);


			if(speed > 0 && !facingRight )
				Flip();	
				
			else if(speed <0 && facingRight)
				Flip();
		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D (Collision2D collInfo){
		if (collInfo.gameObject.tag == "Bomb") {
			anim.SetBool("isHit", true);
			anim.SetFloat("speed", 0.0f);
			Variable.isTimeToNext = true;
			Variable.isPass = false;
			Destroy(collInfo.gameObject);
		}
	}
}
