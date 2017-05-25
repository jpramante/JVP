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

	float timer = 0;

	private bool onAlert = false;

	public enum PLAYERENEMY_TYPE
	{
		ENEMY0,
		ENEMY1
	}

	public PLAYERENEMY_TYPE player_type = PLAYERENEMY_TYPE.ENEMY0;

	void Start () 
	{
		enemyPlayer = "Player0";
		ToggleEnemy ();
		gameObject.name = enemy;
	}

	void Update () 
	{
		LookThePlayer();
		timer += Time.deltaTime;
		shoot ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == enemyPlayer) 
		{
			onAlert = true;
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
			Shot.enemy = enemyPlayer;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
			break;
		case PLAYERENEMY_TYPE.ENEMY1:
			enemy = "Enemy1";
			enemyPlayer = "Player1";
			Shot.enemy = enemyPlayer;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
			break;
		default:
			break;
		}
	}

	public void shoot()
	{
		if (onAlert && timer >= 2.0f)
		{
			Instantiate (shot, gameObject.transform.position, Quaternion.identity);
			timer = 0;
			Invoke ("shoot", 0f);
		}
	}

	public void LookThePlayer()
	{
		GameObject playerEnemy = GameObject.Find (enemyPlayer);
		if (playerEnemy.transform.position.x - gameObject.transform.position.x < 0)
		{
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
			Shot.RotationSet = -1;
		}
		if (playerEnemy.transform.position.x - gameObject.transform.position.x > 0)
		{
			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
			Shot.RotationSet = 1;
		}
	}
}
