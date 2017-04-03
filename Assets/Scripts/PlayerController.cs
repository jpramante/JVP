using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ArcadePUCCampinas;

public class PlayerController : MonoBehaviour {

	public float velocidade_inicial = 700;
	float velocidade;
	float direction;

	public float JumpForce = 700;
	private bool canJump = false;

	Rigidbody2D rb;


	void Start () 
	{
		velocidade = velocidade_inicial;
		//colocar rigidbody no player
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () 
	{

		float direction = Input.GetAxis ("Horizontal");
		if (canJump == false)
			velocidade = (velocidade_inicial / 2);
		else if (canJump == true)
			velocidade = velocidade_inicial;
		
			rb.velocity = new Vector2 (direction * Time.deltaTime * velocidade, rb.velocity.y);

		if (Input.GetButtonDown ("Jump") && canJump == true) 
		{
			rb.AddForce (new Vector2 (0, JumpForce));
		}
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
