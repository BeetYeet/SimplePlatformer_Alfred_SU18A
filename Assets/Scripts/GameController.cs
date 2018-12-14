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
	public bool doorsEnabled = false;
	public SimpleEvent winEvent;
	public SimpleEvent loseEvent;
	public int coinsForCompletion = 5;
	
	void Awake () {
		if ( current != null )
		{
			throw new Exception( "Multiple instances of GameController exist, make sure there is only one" );
		}
		current = this;
		flags = new List<FlagController>();
		doors = new List<DoorController>();
	}

	public void RespawnPlayerAt( Vector2 pos )
	{
		player.transform.position = new Vector3( pos.x, pos.y, 0f );
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
	
	void Update () {

		if ( !flagsEnabled && playerScore >= coinsForCompletion )
		{
			flags.ForEach( ( x ) => { x.Enable(); } );
			flagsEnabled = true;
		}
		if ( !doorsEnabled && Time.time >= 10 )
		{
			doors.ForEach( ( x ) => { x.Enable(); } );
			doorsEnabled = true;
		}
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