using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public static Vector2 resp;
	public static Vector3 spawn;

	public void Respawna (GameObject jogador)
	{
		if(jogador.transform.name == "Player0")
			jogador.transform.position = resp;
		else if(jogador.transform.name == "Player1")
			jogador.transform.position = spawn;
	}
}
