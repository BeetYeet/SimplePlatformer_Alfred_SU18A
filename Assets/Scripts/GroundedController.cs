using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour {

	public Movement playerMovementScript;
	public byte collidedEnteties;

	private void OnTriggerEnter2D( Collider2D collision )
	{
		collidedEnteties++;
		playerMovementScript.isGrounded = collidedEnteties != 0;
	}

	private void OnTriggerExit2D( Collider2D collision )
	{
		collidedEnteties--;
		playerMovementScript.isGrounded = collidedEnteties != 0;
	}
}
