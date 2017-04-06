using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject portao;

	void Start () 
	{
	}

	void Update () 
	{
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			if(col.transform.position.x < gameObject.transform.position.x)
			{
				col.transform.position = new Vector2 (gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + transform.up.y);
				col.GetComponent<Rigidbody2D> ().gravityScale = 100;
			}
			else if(col.transform.position.x > gameObject.transform.position.x)
			{
				col.transform.position = new Vector2 (gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + transform.up.y);
				col.GetComponent<Rigidbody2D> ().gravityScale = 100;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			col.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player0") 
		{
			portao.transform.position = new Vector2 (portao.transform.position.x, portao.transform.position.y - (transform.up.y * 2.5f));
			portao.transform.localScale = new Vector2 (portao.transform.localScale.x, 1f);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.name == "Player0") 
		{
			portao.transform.position = new Vector2 (portao.transform.position.x, portao.transform.position.y + (transform.up.y * 2.5f));
			portao.transform.localScale = new Vector2 (portao.transform.localScale.x, 4);
		}
	}
}
