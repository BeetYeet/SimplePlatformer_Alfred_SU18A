using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	// this script is the exact same as the FlagController and as such simply look at that for descriptions

	public Animator anim;
	public bool doorEnabled = false;
	public SimpleEvent OnTriggered;

	void Start()
	{
		anim.SetBool( "Open", doorEnabled );
		GameController.current.doors.Add( this );
	}

	public void Enable()
	{
		doorEnabled = true;
		anim.SetBool( "Open", doorEnabled );
	}

	public void Trigger()
	{
		if ( doorEnabled )
		{
			OnTriggered.Invoke();
		}
	}
}
