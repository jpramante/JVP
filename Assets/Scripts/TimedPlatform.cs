using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatform : MonoBehaviour {

	public GameObject timedPlatformScript;
    private bool collisionDetected;
    private float platTimer = 0f;

	void Start () 
	{
        collisionDetected = false;
		timedPlatformScript.SetActive(false);
	}
    void OnCollisionEnter2D(Collision2D col) 
	{
        collisionDetected = true;
	}

    void Update()
    {
        if (collisionDetected)
        {
            timedPlatformScript.SetActive(true);
            platTimer += Time.deltaTime;

        }
    }


}
