using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ArcadePUCCampinas;

public class PlayerController : MonoBehaviour {

	public float velocidade;
	float input_x, input_y;

	Rigidbody2D rb;


	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		velocidade = 100 * Time.deltaTime;
	}
	

	void Update () 
	{
		input_x = Input.GetAxisRaw ("Horizontal") * velocidade;
					
		input_y = Input.GetAxisRaw ("Vertical") * velocidade;

		if (input_x != 0 &&) 
		{
			rb.velocity = new Vector3 (1, 0, 0) * input_x;
		}
	}
}
