using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAt : MonoBehaviour {

	public GameObject respawnPosition;	

	public void Trigger () {
		GameController.current.RespawnPlayerAt( respawnPosition.transform.position );
	}
}
