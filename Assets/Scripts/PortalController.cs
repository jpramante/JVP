using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

	private Vector2 CheckPoint,PortalPosition;

	public GameObject PortalDestination;

	void Start ()
	{
		PortalPosition = GameObject.FindGameObjectWithTag ("Spawn").transform.position;
		CheckPoint = PortalPosition;

		Respawn.resp = CheckPoint;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(gameObject.tag == "PortalEnter" || gameObject.tag == "PortalExit")
		{
				if (col.gameObject.name == "Player0" && gameObject.tag == "PortalEnter") 
				{
					PortalPosition = PortalDestination.transform.position;
					col.gameObject.transform.position = PortalPosition;
				}

				if (col.gameObject.name == "Player0")
				{
					CheckPoint = PortalPosition;
					gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					Respawn.resp = CheckPoint;
				}
		}
	}

}
