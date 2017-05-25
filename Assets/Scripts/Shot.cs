using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public float VelocityShot = 1000;
	public static int RotationSet = 1;

	private Respawn resp;

	private Rigidbody2D rb;

	public static string enemy = "";

	void Start () 
	{
		resp = new Respawn();
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = (new Vector2 (VelocityShot * Time.deltaTime * RotationSet, 0));  

		Destroy (gameObject, 2f);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == enemy)
			resp.Respawna (other.gameObject);

		if(other.gameObject.tag == "Player")
			Destroy (gameObject, 0);
	}
}
 