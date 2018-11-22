using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameController : MonoBehaviour {

	//static
	[NonSerialized]
	public static GameController current;

	//dynamic
	public int playerScore;
	public List<FlagController> flags;
	public bool flagsEnabled = false;
	public SimpleEvent winEvent;
	public SimpleEvent loseEvent;

	// Use this for initialization
	void Awake () {
		if ( current != null )
		{
			throw new Exception( "Multiple instances of GameController exist, make sure there is only one" );
		}
		current = this;
		flags = new List<FlagController>();
	}
	
	
	// Update is called once per frame
	void Update () {
		if ( !flagsEnabled && playerScore >= 5 )
		{
			EnableWinFlags();
			flagsEnabled = true;
		}
	}

	public void EnableWinFlags()
	{
		flags.ForEach( ( x ) => { x.Enable(); } );
	}


	public void Win()
	{
	
	}

	public void Lose()
	{
	
	}

}

[Serializable]
public class SimpleEvent: UnityEvent
{

}