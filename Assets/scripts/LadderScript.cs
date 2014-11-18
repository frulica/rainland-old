using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour {

	public Player player;


	bool onLadder, canClimb;
	float speed = 10f;
	float oldGravity;
	
	void Start() {
		player.rigidbody2D.isKinematic = false;
		oldGravity = player.rigidbody2D.gravityScale;
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
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			ClimbMode();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			ClimbMode();
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other)
	{
		//exit climb mode
		onLadder = false;
		player.rigidbody2D.gravityScale = oldGravity;
	}

	void ClimbMode()
	{
		onLadder = true;
		player.rigidbody2D.gravityScale = 0;
		player.rigidbody2D.velocity = Vector2.zero;
	}
	
}


