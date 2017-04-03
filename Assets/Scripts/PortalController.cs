using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour {

	GameObject PortalExit;
	GameObject PortalEnter;

	int SizePortal;
	int posi;

	public GameObject[] PortaisEnter =  new GameObject[(1)];
	public GameObject[] PortaisExit = new GameObject[(1)];

	void Start ()
	{
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
					Vector2 PortalPosition = PortaisExit [posi].transform.position;
					gameObject.transform.position = PortalPosition;
				}
			}

		}
		if (col.gameObject.tag == "EndFase") 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
