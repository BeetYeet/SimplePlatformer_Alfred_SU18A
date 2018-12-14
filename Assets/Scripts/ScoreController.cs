using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController: MonoBehaviour
{

	TextMeshProUGUI GUI;

	// Use this for initialization
	void Start()
	{
		// cashe the variable
		GUI = this.GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		// update the text
		GUI.text = GameController.current.playerScore.ToString( "D2" );
	}
}
