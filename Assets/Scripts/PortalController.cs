using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {

	private Vector2 CheckPoint,PortalPosition;

	private int SizePortal;
	private int posi;

	private GameObject[] PortaisEnter =  new GameObject[1];
	private GameObject[] PortaisExit = new GameObject[1];

	private string PortalName;

	public enum PORTALNUM
	{
		P0,
		P1,
		P2,
		P3,
		P4
	}

	public PORTALNUM player_type = PORTALNUM.P0;

	void Start ()
	{
		PortalPosition = GameObject.FindGameObjectWithTag ("Spawn").transform.position;
		CheckPoint = PortalPosition;

		Respawn.resp = CheckPoint;

		SizePortal = GameObject.FindGameObjectsWithTag("PortalEnter").Length;

		//adicionar as tags "PortalExit" e "PortalEnter" dos portais
		PortaisExit = new GameObject[SizePortal];
		PortaisEnter = new GameObject[SizePortal];

		PortaisExit = GameObject.FindGameObjectsWithTag ("PortalExit");
		PortaisEnter = GameObject.FindGameObjectsWithTag ("PortalEnter");

		TogglePortal ();
		orderPortals ();

		gameObject.name = PortalName;
	}

	void Update()
	{	
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(gameObject.tag == "PortalEnter" || gameObject.tag == "PortalExit")
		{
			for(posi = 0; posi <= SizePortal - 1; posi++)//inicia o for para rodar a array para localizar qual o portal que esta colidindo
			{
				if (col.gameObject.name == "Player0" && gameObject.name == PortalName) 
				{
					PortalPosition = PortaisExit [posi].transform.position;
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

	public void TogglePortal()
	{
		switch (player_type)
		{
		case PORTALNUM.P0:
			PortalName = "0_Portal";
			break;
		case PORTALNUM.P1:
			PortalName = "1_Portal";
			break;
		case PORTALNUM.P2:
			PortalName = "2_Portal";
			break;
		case PORTALNUM.P3:
			PortalName = "3_Portal";
			break;
		case PORTALNUM.P4:
			PortalName = "4_Portal";
			break;
		default:
			break;
		}
	}

	public void orderPortals()
	{
		GameObject aux;

		for (int i = 1; i < SizePortal; i++) 
		{
			for (int c = 1; c < SizePortal; c++) 
			{
				char[] PEnteraux = PortaisEnter[c].name.ToCharArray();

				if (int.Parse(PEnteraux[c].ToString()) > int.Parse(PEnteraux[c-1].ToString())) 
				{
					aux = this.PortaisEnter[c - 1];
					this.PortaisEnter[c - 1] = this.PortaisEnter[c];
					this.PortaisEnter[c] = aux;
				}

				char[] PExitAux = PortaisExit [c].name.ToCharArray ();

				if (int.Parse(PExitAux[c].ToString()) > int.Parse(PExitAux[c-1].ToString())) 
				{
					aux = this.PortaisExit[c - 1];
					this.PortaisExit[c - 1] = this.PortaisExit[c];
					this.PortaisExit[c] = aux;
				}
			}
		}
	}
}
