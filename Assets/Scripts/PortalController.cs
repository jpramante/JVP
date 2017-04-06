using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

	GameObject PortalExit;
	GameObject PortalEnter;
	GameObject Spawn;

	Vector2 CheckPoint,PortalPosition;

	int SizePortal;
	int posi;

	public GameObject[] PortaisEnter =  new GameObject[(1)];
	public GameObject[] PortaisExit = new GameObject[(1)];

	void Start ()
	{
		Spawn = GameObject.Find ("Spawn");

		CheckPoint = Spawn.transform.position;
		SizePortal = PortaisEnter.Length;

		//adicionar as tags "PortalExit" e "PortalEnter" dos portais
		PortalExit = GameObject.FindGameObjectWithTag ("PortalExit");
		PortalEnter = GameObject.FindGameObjectWithTag ("PortalEnter");
	}
	void Update()
	{		
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		for(posi = 0; posi <= SizePortal - 1; posi++)//inicia o for para rodar a array para localizar qual o portal que esta colidindo
		{
			if (PortaisEnter[posi] == col.gameObject)//verifica se o portal que foi colidido pelo player é igual ao do loop
			{
				if (col.gameObject.tag == "PortalEnter") {
					PortalPosition = PortaisExit [posi].transform.position;
					gameObject.transform.position = PortalPosition;
				}
			}

		}

		if (col.gameObject.tag == "PortalExit") 
		{
			Debug.Log ("Check");
			CheckPoint = PortalPosition;
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			GameObject Spawn = GameObject.FindGameObjectWithTag ("Spawn");
			Spawn.SetActive(false);
		}
		if (col.gameObject.tag == "LineOut") 
		{
			gameObject.transform.position = CheckPoint;
		}

	}
}
