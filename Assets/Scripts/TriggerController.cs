using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

	public SimpleEvent OnEnter;
	public SimpleEvent OnExit;
	public uint numTouch;

	private void OnTriggerEnter2D( Collider2D collision )
	{
		numTouch++;
		OnEnter.Invoke();
	}

	private void OnTriggerExit2D( Collider2D collision )
	{
		numTouch--;
		if(numTouch==0)
			OnExit.Invoke();
	}
}
