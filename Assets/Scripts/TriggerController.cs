using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

	public SimpleEvent OnEnter;
	public SimpleEvent OnExit;
	public uint numTouch;


	// function that is called when a collider goes into the area of the trigger
	private void OnTriggerEnter2D( Collider2D collision )
	{
		// increase the number of collisions occuring
		numTouch++;
		// call the event
		OnEnter.Invoke();
	}

	// function that is called when a collider goes out of the area of the trigger
	private void OnTriggerExit2D( Collider2D collision )
	{
		numTouch--;
		// decrease the number of collisions occuring

		// if the trigger now has 0 objects in it
		if ( numTouch == 0 )
		{
			// call the event
			OnExit.Invoke();
		}
	}
}
