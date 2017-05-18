//
//	EnemyController for unity3D 5.5.2
//	Created By Pedro Gomes
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private string enemyPlayer, enemy;

	//Shooter shooter;

	public GameObject shot;

	private bool onAlert = false;

	public enum PLAYERENEMY_TYPE
	{
		ENEMY0,
		ENEMY1
	}

	public PLAYERENEMY_TYPE player_type = PLAYERENEMY_TYPE.ENEMY0;

	void Start () 
	{
		ToggleEnemy ();
		enemyPlayer = "Player0";
		gameObject.name = enemy;
	}

	void Update () 
	{
		ToggleEnemy ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == enemyPlayer) 
		{
			onAlert = true;
			shoot ();
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == enemyPlayer) 
			onAlert = false;
	}

	public void ToggleEnemy()
	{
		switch (player_type)
		{
		case PLAYERENEMY_TYPE.ENEMY0:
			enemy = "Enemy0";
			enemyPlayer = "Player0";
			gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
			break;
		case PLAYERENEMY_TYPE.ENEMY1:
			enemy = "Enemy1";
			enemyPlayer = "Player1";
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
			break;
		default:
			break;
		}
	}

	public void shoot()
	{
		if (onAlert == true) 
		{
			Instantiate (shot, gameObject.transform.position, Quaternion.identity);
			Invoke ("shoot", 2f);
		}
	}
}
