using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
		rb.AddForce (new Vector3 (-300 * Time.deltaTime, 0));
		Destroy (gameObject, 2.5f);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player0" && gameObject.name == "shot0")
		{
			Destroy (gameObject);
		}
			
	}
}
