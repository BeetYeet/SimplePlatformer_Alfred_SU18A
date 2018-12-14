using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	// called when the coin is touched by the player
	public void Trigger()
	{
		// increase the score
		GameController.current.playerScore++;
		// Remove the coin
		Destroy( gameObject );
	}
}
