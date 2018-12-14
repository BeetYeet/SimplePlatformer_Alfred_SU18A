using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAt : MonoBehaviour {

	public GameObject respawnPosition;	

	// function to trigger when the player should respawn
	public void Trigger () {
		// use the function in the GameController to respawn the player with the position of the spawn point
		GameController.current.RespawnPlayerAt( respawnPosition.transform.position );
	}
}
