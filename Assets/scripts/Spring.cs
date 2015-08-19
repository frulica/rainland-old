using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

	public float force = 100f;
	bool alreadyBounced = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!alreadyBounced)
		{
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, force));
			alreadyBounced = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		alreadyBounced = false;
	}
}
