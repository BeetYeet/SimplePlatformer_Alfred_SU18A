using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController: MonoBehaviour
{

	public Animator anim;
	public bool flagEnabled = false;
	public SimpleEvent OnTriggered;
	
	// called at the beginning of the game
	void Start()
	{
		// make sure the flag is updated to the default state (should be false in most cases)
		anim.SetBool( "Enabled", flagEnabled );
		// cashe this flag into the GameController
		GameController.current.flags.Add( this );
	}

	// to enable the flag
	public void Enable()
	{
		// set the variable
		flagEnabled = true;
		// set the animation variable
		anim.SetBool( "Enabled", flagEnabled );
	}

	// to try and load the new level
	public void Trigger()
	{
		// if this flag is enabled
		if ( flagEnabled )
		{
			// call the event
			OnTriggered.Invoke();
		}	
	}
}
