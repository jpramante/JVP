using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour {

	GameObject PortalExit;
	GameObject PortalEnter;

	void Start ()
	{
		//adicionar as tags "PortalExit" e "PortalEnter" dos portais
		PortalExit = GameObject.FindGameObjectWithTag ("PortalExit");
		PortalEnter = GameObject.FindGameObjectWithTag ("PortalEnter");
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "PortalEnter") 
		{
			Vector2 PortalPosition = PortalExit.transform.position;
			gameObject.transform.position = PortalPosition;
		}
		if (col.gameObject.tag == "EndFase") 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
