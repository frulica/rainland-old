using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour {

	public Player player;


	bool onLadder, canClimb;
	float speed = 10f;
	float oldGravity;
	
	void Start() {
		player.GetComponent<Rigidbody2D>().isKinematic = false;
		oldGravity = player.GetComponent<Rigidbody2D>().gravityScale;
	}
	
	void Update () {
		if (onLadder)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				player.transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				player.transform.Translate(0,Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
			}

		}
	}
	
	
	void OnTriggerStay2D(Collider2D other)
	{
		//Debug.Log ("STAY");
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			ClimbMode();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("IN");
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			ClimbMode();
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other)
	{
		//exit climb mode
		onLadder = false;
		player.GetComponent<Rigidbody2D>().gravityScale = oldGravity;
		//Debug.Log ("OUT");
	}

	void ClimbMode()
	{
		onLadder = true;
		player.GetComponent<Rigidbody2D>().gravityScale = 0;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

	}
	
}


