using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFaseController : MonoBehaviour {


	bool P0Ganhou, P1Ganhou;

	void Start () 
	{
		P0Ganhou = false;
		P1Ganhou = false;	
	}

	void Update () 
	{
		if(P0Ganhou == true && P1Ganhou ==  true)
		{
			Debug.Log ("Ganhou aeeeee");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}	
	}
	void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.name == "Player0")
			P0Ganhou = true;
		if (col.gameObject.name == "Player1") 
			P1Ganhou = true;
	}
	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.name == "Player0")
			P0Ganhou = false;
		if(col.gameObject.name == "Player1")
			P1Ganhou = false;
	}
}
