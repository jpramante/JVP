using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ArcadePUCCampinas;

public class PlayerController : MonoBehaviour {

	public float velocidade = 1500;
	float direction;

	public float JumpForce = 500;
	private bool canJump = false;

	Rigidbody2D rb;


	void Start () 
	{
		//colocar rigidbody no player
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () 
	{
		if (Input.GetButtonDown ("Jump") && canJump == true) 
		{
			rb.AddForce (new Vector2 (0, JumpForce));
		}
		
		float direction = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(direction * Time.deltaTime * velocidade, rb.velocity.y);
	}
	void OnCollisionEnter2D(Collision2D other)
	{       
		//colocar a tag Chao
		if (other.gameObject.tag == "Chao") {
			canJump = true;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Chao") {
			canJump = false;
		}
	}
}
