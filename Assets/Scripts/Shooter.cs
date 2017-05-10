using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	private Rigidbody2D rb;

	private string shooter, destiny;

	Respawn respawn;

	private float direction;

	//private GameObject destinyGO;

	public void Shoot(string shooter)
	{
		this.shooter = shooter;
	}

	void Start () 
	{
		//setDestination ();
		//destinyGO = GameObject.Find (destiny);
	}

	void Update ()
	{
		gameObject.transform.Translate(gameObject.transform.right * 2 * Time.deltaTime); 
		//Debug.Log (gameObject.transform.position);
		Destroy (gameObject, 2.5f);
	}

	void setDestination()
	{
		switch (shooter) 
		{
			case "Player0":
				destiny = "Enemy0";
				break;
			case "Player1":
				destiny = "Enemy1";
				break;
			case "Enemy0":
				destiny = "Player0";
				break;
			case "Enemy1":
				destiny = "Player1";
				break;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == destiny) 
		{
			if (destiny == "Enemy0" || destiny == "Enemy1")
			{
				Destroy (col.gameObject);
				Destroy (gameObject);
			}

			if (destiny == "Player0" || destiny == "Player1")
			{
				respawn = new Respawn();
				respawn.Respawna (col.gameObject);
				Destroy (gameObject);
			}
		}
		if (col.gameObject.tag == "Player" && gameObject.name == "shot1") 
		{
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
		Destroy (gameObject);
	}
}
