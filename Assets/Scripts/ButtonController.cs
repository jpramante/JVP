using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject portao;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Player1") 
		{
			Destroy (portao, 0.1f);
		}
	}
}


