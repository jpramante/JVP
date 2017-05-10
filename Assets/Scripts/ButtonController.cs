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
		if (col.gameObject.name == "Player0") 
		{
			Destroy (portao, 0.1f);
		}
	}
}


