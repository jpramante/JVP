using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public float VelocityShot = 1000;
	public static int RotationSet = 1;
	Rigidbody2D rb;


	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();

		rb.velocity = (new Vector2 (VelocityShot * Time.deltaTime * RotationSet, 0));
	}
}
 