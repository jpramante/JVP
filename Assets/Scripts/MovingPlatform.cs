using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.parent = gameObject.transform;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        col.transform.parent = null;
    }
}

