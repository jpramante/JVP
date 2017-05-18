using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcadePUCCampinas;

public class PlayerController : MonoBehaviour {

	public float Start_Velocity = 400;
	private float Velocity;

	public float JumpForce = 350;
	private bool canJump0, canJump1;

	private Rigidbody2D rb;
	private Animator play;
	private SpriteRenderer sprite;


	void Start () 
	{
		Velocity = Start_Velocity;
		play = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer> ();
	}
	

	void Update () 
	{
		Player0 ();
		Player1 ();
		//Debug.Log(canJump1);
	}


	void Player0()
	{
		if (gameObject.name == "Player0")
		{			
			float direction = InputArcade.Eixo(0, EEixo.HORIZONTAL);

			rb = GetComponent<Rigidbody2D> ();

			if (canJump0 == false) {
				Velocity = (Start_Velocity / 2);
			} else if (canJump0 == true) {
				Velocity = Start_Velocity;
			}

			if (InputArcade.Apertou (0, EControle.VERDE) && canJump0 == true) 
			{
				rb.AddForce (new Vector2 (0, JumpForce));
			}
			if (Input.GetKey(KeyCode.D)) 
			{
				sprite.flipX = false;
				play.Play("RunP0");
			}
			else if (Input.GetKey (KeyCode.A)) 
			{
				sprite.flipX = true;
				play.Play("RunP0");
			}
			else
				play.Play("Idle_black");
			rb.velocity = new Vector2 (direction * Time.deltaTime * Velocity, rb.velocity.y);
		}	
	}
	void Player1()
	{
		if (gameObject.name == "Player1")
		{
			float direction = InputArcade.Eixo(1, EEixo.HORIZONTAL);

			rb = GetComponent<Rigidbody2D> ();

			if (canJump1 == false)
				Velocity = (Start_Velocity / 2);
			else if (canJump1 == true)
				Velocity = Start_Velocity;

			if (InputArcade.Apertou (1, EControle.VERDE) && canJump1 == true) 
			{
				rb.AddForce (new Vector2 (0, JumpForce));
			}
			if (Input.GetKey(KeyCode.RightArrow)) 
			{
				sprite.flipX = false;
				play.Play("Run2");
			}
			else if (Input.GetKey (KeyCode.LeftArrow)) 
			{
				sprite.flipX = true;
				play.Play("Run2");
			}
			else
				play.Play("IdleP2");
			
			rb.velocity = new Vector2 (direction * Time.deltaTime * Velocity, rb.velocity.y);
		}	
	}
	void OnCollisionEnter2D(Collision2D other)
	{       
		//colocar a tag Chao
		if (other.gameObject.tag == "Chao" ||  other.gameObject.tag == "Botao" && gameObject.name == "Player0") 
		{
			canJump0 = true;
		}
		if (other.gameObject.tag == "Chao"  && gameObject.name == "Player1")
		{
			canJump1 = true;
		}

		if (other.gameObject.name == "Player1" && gameObject.name == "Player0") {
			Physics2D.IgnoreCollision (other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Chao" || other.gameObject.tag == "Botao" && gameObject.name == "Player0")
		{
			canJump0 = false;
		}
		if (other.gameObject.tag == "Chao"  && gameObject.name == "Player1")
		{
			Debug.Log(canJump1);
			canJump1 = false;
		}
	}
}
