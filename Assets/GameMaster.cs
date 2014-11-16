using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	public Transform playerPrefab;
	public Transform spawnPoint;
	public int spawnDelay = 2;

	void Start() {
		if (gm == null){
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		}
	}

	public static void KillPlayer(Player player){
		//Destroy (player.gameObject);
		gm.RespawnPlayer (player);
	}

	public void RespawnPlayer(Player player) {
		//yield return new WaitForSeconds (spawnDelay);
		//Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		player.transform.position = spawnPoint.transform.position;
	}

}
