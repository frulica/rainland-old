using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats {
		public int health = 100;

	}

	public PlayerStats playerStats = new PlayerStats();

	public int fallBoundry;

	void Update(){
		if (transform.position.y <= fallBoundry) {
			DamagePlayer(playerStats.health);
		}
	}

	void DamagePlayer(int damage ){
		playerStats.health -= damage;
		if (playerStats.health < 1) {
			GameMaster.KillPlayer(this);
		}
	}
}
