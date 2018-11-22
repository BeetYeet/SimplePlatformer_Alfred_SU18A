using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	public void Trigger()
	{
		GameController.current.playerScore++;
		Destroy( gameObject );
	}
}
