using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController: MonoBehaviour
{

	public Animator anim;
	public bool flagEnabled = false;
	public SimpleEvent OnTriggered;
	
	void Start()
	{
		anim.SetBool( "Enabled", flagEnabled );
		GameController.current.flags.Add( this );
	}

	public void Enable()
	{
		flagEnabled = true;
		anim.SetBool( "Enabled", flagEnabled );
	}

	public void Trigger()
	{
		if ( flagEnabled )
		{
			OnTriggered.Invoke();
		}	
	}
}
