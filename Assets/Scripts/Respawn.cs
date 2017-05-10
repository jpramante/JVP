using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public static Vector2 resp;

	public void Respawna (GameObject jogador)
	{
		jogador.transform.position = resp;
	}
}
