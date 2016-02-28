using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

	public float force = 100f;
	private float total_force = 100F;
	bool alreadyBounced = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		total_force = force;
		if (!alreadyBounced)
		{
			other.GetComponent<PlatformerCharacter2D> ().grounded = false;
			
			if (Input.GetKey (KeyCode.Space)) {
				total_force = force * 2;
			}
			other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, total_force));
			alreadyBounced = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		alreadyBounced = false;
	}
}
