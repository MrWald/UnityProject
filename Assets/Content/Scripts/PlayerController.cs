using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed = 1;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	private bool isGrounded = false;
	private bool JumpActive = false;
	private float JumpTime = 0f;
	
	Rigidbody2D myBody = null;
	
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
		LevelController.current.setStartPosition (transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () 
	{ 
		Animator animator = GetComponent<Animator> (); 
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f; 
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");
//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if(hit) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
//Намалювати лінію (для розробника)
		Debug.DrawLine (from, to, Color.red);
		
		if(Input.GetButtonDown("Jump") && isGrounded) 
		{
			this.JumpActive = true; 
		}
		if(this.JumpActive) 
		{
//Якщо кнопку ще тримають
			if(Input.GetButton("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime); 
					myBody.velocity = vel;
				}
			} else {
				this.JumpActive = false;
				this.JumpTime = 0; 
			}
		}
		//[-1, 1]
		float value = Input.GetAxis ("Horizontal");
		if(this.isGrounded) {
			animator.SetBool ("jump", false);
		} else {
			animator.SetBool ("jump", true);
		}

		if (Mathf.Abs (value) > 0) 
		{
			animator.SetBool ("run", true);
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
			SpriteRenderer sr = GetComponent<SpriteRenderer>(); 
			if(value < 0) 
			{
				sr.flipX = true;
			} 
			else if(value > 0) 
			{
				sr.flipX = false;
			}
		} 
		else 
		{
			animator.SetBool ("run", false); 
		}
	}
}
