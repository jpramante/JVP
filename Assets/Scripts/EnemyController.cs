using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject shot0, shot1;
	bool player0Aqui, player1Aqui;

	void Start () 
	{
		player0Aqui = false;
		player1Aqui = false;
	}

	void Update () 
	{
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
	}
	void OnCollisionExit2D(Collision2D col)
	{

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Player0" && player0Aqui == false && gameObject.tag == "Enemy0") 
		{
			Debug.Log("Entrou");
			player0Aqui = true;
			Invoke ("SpawnaShot", 1);
		}
		if (col.gameObject.name == "Player1" && player1Aqui == false && gameObject.tag == "Enemy1") 
		{
			Debug.Log("Entrou");
			player1Aqui = true;
			Invoke ("SpawnaShot", 1);
		}

	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "Player0")
		{
			Debug.Log("Saiu");
			player0Aqui = false;
		}
		if (col.gameObject.name == "Player1")
		{
			Debug.Log("Saiu");
			player1Aqui = false;
		}
	}

	void SpawnaShot()
	{
		if (player0Aqui == true) 
		{
			Instantiate (shot0, gameObject.transform.position, Quaternion.identity);
			Invoke ("SpawnaShot", 3);
		}
		if (player1Aqui == true) 
		{
			Instantiate (shot1, gameObject.transform.position, Quaternion.identity);
			Invoke ("SpawnaShot", 3);
		}
	}
}
