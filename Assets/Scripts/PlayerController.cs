using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcadePUCCampinas;

public class PlayerController : MonoBehaviour {

	public float velocidade_inicial = 400;
	float velocidade;

	public float JumpForce = 400;
	private bool canJump0, canJump1 = false;

	Rigidbody2D rb;


	void Start () 
	{
		velocidade = velocidade_inicial;
	}
	

	void Update () 
	{
		Player0 ();
		Player1 ();
	}


	void Player0()
	{
		if (gameObject.name == "Player0")
		{			
			float direction = InputArcade.Eixo(0, EEixo.HORIZONTAL);

			rb = GetComponent<Rigidbody2D> ();

			if (canJump0 == false) {
				velocidade = (velocidade_inicial / 2);
			} else if (canJump0 == true) {
				velocidade = velocidade_inicial;
			}

			if (InputArcade.Apertou (0, EControle.VERDE) && canJump0 == true) 
			{
				rb.AddForce (new Vector2 (0, JumpForce));
			}
			rb.velocity = new Vector2 (direction * Time.deltaTime * velocidade, rb.velocity.y);
		}	
	}
	void Player1()
	{
		if (gameObject.name == "Player1")
		{
			float direction = InputArcade.Eixo(1, EEixo.HORIZONTAL);

			rb = GetComponent<Rigidbody2D> ();

			if (canJump1 == false)
				velocidade = (velocidade_inicial / 2);
			else if (canJump1 == true)
				velocidade = velocidade_inicial;

			if (InputArcade.Apertou (1, EControle.VERDE) && canJump1 == true) 
			{
				rb.AddForce (new Vector2 (0, JumpForce));
			}
			rb.velocity = new Vector2 (direction * Time.deltaTime * velocidade, rb.velocity.y);
		}	
	}
	void OnCollisionEnter2D(Collision2D other)
	{       
		//colocar a tag Chao
		if (other.gameObject.tag == "Chao" && gameObject.name == "Player0") 
		{
			canJump0 = true;
		}
		else if (other.gameObject.tag == "Chao" && gameObject.name == "Player1")
		{
			canJump1 = true;
		}

		if (other.gameObject.name == "Player1" && gameObject.name == "Player0") {
			Physics2D.IgnoreCollision (other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Chao" && gameObject.name == "Player0")
		{
			canJump0 = false;
		}
		else if (other.gameObject.tag == "Chao" && gameObject.name == "Player1")
		{
			canJump1 = false;
		}
	}
}
