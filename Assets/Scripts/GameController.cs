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
	public GameObject player;
	public int playerScore;
	public List<FlagController> flags;
	public List<DoorController> doors;
	public bool flagsEnabled = false;
	// supports doors, but didnt really have a good use for them, 
	// they would have moved the player across the level instead of switching level
	public bool doorsEnabled = false;
	public SimpleEvent winEvent;
	public SimpleEvent loseEvent;
	public int coinsForCompletion = 5;
	
	// called as soon as the script is enabled (a bit quicker than Start())
	void Awake () {
		// if there is already a GameController
		if ( current != null )
		{
			// make sure the dev knows
			throw new Exception( "Multiple instances of GameController exist, make sure there is only one" );
		}
		// cashe this instance into the static class
		current = this;
		// initialize the list
		flags = new List<FlagController>();
		// initialize the list
		doors = new List<DoorController>();
	}

	// helper function for respawning the player
	public void RespawnPlayerAt( Vector2 pos )
	{
		// set the new position
		player.transform.position = new Vector3( pos.x, pos.y, 0f );
		// set the velocity
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
	
	// called once per frame
	void Update () {

		// if we havent enabled flags yet and the player has collected enough coins
		if ( !flagsEnabled && playerScore >= coinsForCompletion )
		{
			// for each flag, enable the flag
			flags.ForEach( ( x ) => { x.Enable(); } );
			// set the variable so we dont call Enable multiple times
			flagsEnabled = true;
		}
		if ( !doorsEnabled && Time.time >= 10 )
		{
			// for each door, enable the door
			doors.ForEach( ( x ) => { x.Enable(); } );
			// set the variable so we dont call Enable multiple times
			doorsEnabled = true;
		}
	}

	// if you want to do fancy stuff, heres the infrastructure:
	public void Win()
	{
	
	}

	public void Lose()
	{
	
	}

}

// event class to make stuff look neat and cooperate in unity
[Serializable]
public class SimpleEvent: UnityEvent
{

}