using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour {

	public Movement playerMovementScript;
	public byte collidedEnteties;


	// on colliding with an entity
	private void OnTriggerEnter2D( Collider2D collision )
	{
		// add one to the amount of colliding enteties
		collidedEnteties++;
		// recalculate weather the player is grounded
		playerMovementScript.isGrounded = collidedEnteties != 0;
	}

	// on no longer colliding with an entity
	private void OnTriggerExit2D( Collider2D collision )
	{
		// remove one from the amount of colliding enteties
		collidedEnteties--;
		// recalculate weather the player is grounded
		playerMovementScript.isGrounded = collidedEnteties != 0;
	}
}
