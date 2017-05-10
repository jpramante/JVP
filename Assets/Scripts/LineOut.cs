using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOut : MonoBehaviour {

	private Respawn respawn;

	void Start () 
	{
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		respawn = new Respawn ();
		respawn.Respawna(col.gameObject);
	}
}
