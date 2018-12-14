using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( BoxCollider2D ) )]
public class Movement: MonoBehaviour
{

	[Range( 0f, 20f )]
	public float movementSpeed;
	public float jumpForce;
	public float jumpForceContinous;
	public float jumpForceMultiplier;
	public AnimationCurve jumpForceMultiplierDecay;
	public float jumpForceMultiplierSpan;
	public float jumpTime;
	public bool isGrounded = true;
	public bool waitForFall = false;
	public BoxCollider2D groundedCollider;

	private Rigidbody2D rb;
	private BoxCollider2D col;

	Vector2 camLook = new Vector2( 0f, 0f );
	public GameObject playerCamera;
	public float camReturn;
	public float maxLook;
	public Vector3 camDefaultPos;

	Vector3 smoothPos;
	public float smoothReturn;

	// called at the start of the game
	void Start()
	{
		// cashe the player
		GameController.current.player = gameObject;
		// cashe the rigidbody
		rb = this.GetComponent<Rigidbody2D>();
		// cashe the collider
		col = this.GetComponent<BoxCollider2D>();
	}

	// called once per frame
	void Update()
	{
		// movement stuff
		DoMovement();
		// camera smoothing stuff
		DoCamera();
	}

	// camera smoothing stuff
	private void DoCamera()
	{
		// lerp for smoothing between the current pos and the next
		smoothPos = Vector3.Lerp( smoothPos, this.transform.position, smoothReturn * Time.deltaTime );
		
		// make the difference smaller so that the camera eventually returns
		camLook *= 1 - ( camReturn * Time.deltaTime );
		// math to sum everything up
		playerCamera.transform.position = 
			smoothPos + 
			camDefaultPos + 
			new Vector3( camLook.x, camLook.y, -10f );
	}

	// movement stuff
	void DoMovement()
	{
		// get the input
		Move( Input.GetAxis( "Horizontal" ) );
		// if the player wants to look upward
		if ( Input.GetKey( KeyCode.W ) )
		{
			// look up
			Look( 1f );
		}
		// if the player wants to look downward
		if ( Input.GetKey( KeyCode.S ) )
		{
			// look down
			Look( -1f );
		}

		// if we're on the ground
		if ( isGrounded )
		{
			// and the player wants to jump
			if ( Input.GetKeyDown( KeyCode.Space ) )
			{
				// jump
				Jump();
			}
		}

	}

	// on physics frames
	private void FixedUpdate()
	{
		// if the player is in the air and still flying
		if ( !isGrounded && waitForFall )
		{
			// if the player wants to start falling
			if ( Input.GetKeyUp( KeyCode.Space ) )
			{
				// stop waiting
				waitForFall = false;
				// reset the variable
				jumpForceMultiplier = 1f;
			}
			// otherwise
			else
			{	
				// give the player a boost to stay mid-air
				rb.AddForce( Vector2.up * jumpForceContinous * Time.fixedDeltaTime * jumpForceMultiplier );
				// recalculate
				RecalculateMultiplier();
			}
		}
	}

	void RecalculateMultiplier()
	{
		// use the animation curve (jumpForceMultiplierDecay) 
		// and the max jump boost time (jumpForceMultiplierSpan) 
		// together with the time the player has been in the air to check how much of a boost the player has left
		jumpForceMultiplier = jumpForceMultiplierDecay.Evaluate( ( Time.time - jumpTime ) / jumpForceMultiplierSpan );
	}

	// to look up or down
	private void Look( float vel )
	{
		// lerp the vector so that we can look up and down smoothly
		camLook = Vector2.Lerp( camLook, new Vector2( 0, maxLook * vel ), camReturn * Time.deltaTime );
	}

	// for jumping
	private void Jump()
	{
		// add an initial force
		rb.AddForce( Vector2.up * jumpForce );
		// set the variable so the script can start waiting for the player to release space
		waitForFall = true;
		// cashe the time the jump started
		jumpTime = Time.time;
	}

	// for moving
	private void Move( float vel )
	{
		// calculate the velocity the player should have
		rb.velocity = new Vector2( movementSpeed * vel, rb.velocity.y );
	}
}
