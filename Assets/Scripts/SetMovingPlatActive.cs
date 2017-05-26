using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMovingPlatActive : MonoBehaviour {

    public GameObject movingPlatform;

        void OnTriggerEnter2D(Collider2D col)
	{
            if (col.gameObject.name == "Player1")
            {
                movingPlatform.SetActive(true);
            }
        }

    }
