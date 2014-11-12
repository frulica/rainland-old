using UnityEngine;
using System.Collections;

public class OneWayScript : MonoBehaviour {

	public BoxCollider2D platform;
	public bool oneWay = false;

	// Update is called once per frame
	void Update () 
	{
		platform.enabled = !oneWay; 
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		oneWay = true;
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		oneWay = true;
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		oneWay = false;
	}

}
