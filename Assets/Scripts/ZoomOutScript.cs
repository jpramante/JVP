using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutScript : MonoBehaviour {

	//Camera cam0, cam1;
	public GameObject cam0, cam1;

	int zoomOut = 120;
	int normal = 40;
	float smooth = 5;

	bool P0Col = false; 
	bool P1Col = false;

	void Update ()
	{
		if (P0Col == true) 
			cam0.GetComponent<Camera> ().fieldOfView = Mathf.Lerp (cam0.GetComponent<Camera> ().fieldOfView, zoomOut, Time.deltaTime * smooth);
		else if (P0Col == false)
			cam0.GetComponent<Camera> ().fieldOfView = Mathf.Lerp (cam0.GetComponent<Camera> ().fieldOfView, normal, Time.deltaTime * smooth);
		if (P1Col == true) 
			cam1.GetComponent<Camera> ().fieldOfView = Mathf.Lerp (cam1.GetComponent<Camera> ().fieldOfView, zoomOut, Time.deltaTime * smooth);
		else if (P1Col == false)
			cam1.GetComponent<Camera> ().fieldOfView = Mathf.Lerp (cam1.GetComponent<Camera> ().fieldOfView, normal, Time.deltaTime * smooth);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			if(col.gameObject.name == "Player0")
				P0Col = true;
			if(col.gameObject.name == "Player1")
				P1Col = true;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			if(col.gameObject.name == "Player0" )
				P0Col = false;
			if(col.gameObject.name == "Player1")
				P1Col = false;
		}
	}
}
