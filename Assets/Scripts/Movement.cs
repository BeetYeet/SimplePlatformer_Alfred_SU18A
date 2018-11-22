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
	public Vector3 smoothVel;
	public float velAgressiveness;
	public float velocityMultiplier;

	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		col = this.GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		DoMovement();
		DoCamera();
	}

	private void DoCamera()
	{
		smoothPos = Vector3.Lerp( smoothPos, this.transform.position, smoothReturn * Time.deltaTime );
		smoothVel = Vector3.Lerp( smoothVel, rb.velocity * velocityMultiplier, smoothReturn * Time.deltaTime );

		//Vector3 agressive = new Vector3( smoothVel.x * smoothVel.x, smoothVel.y * smoothVel.y, smoothVel.z * smoothVel.z );
		//Vector3 velLook = Vector3.Lerp( smoothVel, agressive, velAgressiveness * Time.deltaTime );


		camLook *= 1 - ( camReturn * Time.deltaTime );
		playerCamera.transform.position = 
			//new Vector3( 0, velLook.y, 0 ) + 
			smoothPos + 
			camDefaultPos + 
			new Vector3( camLook.x, camLook.y, -10f );
	}

	void DoMovement()
	{


		{
			float _ = Input.GetAxis( "Horizontal" );
			if ( _ != 0f )
			{
				Move( _ );
			}
		}
		if ( Input.GetKey( KeyCode.W ) )
		{
			Look( 1f );
		}
		if ( Input.GetKey( KeyCode.S ) )
		{
			Look( -1f );
		}

		if ( isGrounded )
		{
			if ( Input.GetKeyDown( KeyCode.Space ) )
			{
				Jump();
			}
		}

	}

	private void FixedUpdate()
	{
		if ( !isGrounded && waitForFall )
		{
			if ( Input.GetKeyUp( KeyCode.Space ) )
			{
				waitForFall = false;
				jumpForceMultiplier = 1f;
			}
			else
			{
				rb.AddForce( Vector2.up * jumpForceContinous * Time.deltaTime * jumpForceMultiplier );
				RecalculateMultiplier();
			}
		}
	}

	void RecalculateMultiplier()
	{
		jumpForceMultiplier = jumpForceMultiplierDecay.Evaluate( ( Time.time - jumpTime ) / jumpForceMultiplierSpan );
	}

	private void Look( float vel )
	{
		camLook = Vector2.Lerp( camLook, new Vector2( 0, maxLook * vel ), camReturn * Time.deltaTime );
	}

	private void Jump()
	{
		rb.AddForce( Vector2.up * jumpForce );
		waitForFall = true;
		jumpTime = Time.time;
	}

	private void Move( float vel )
	{
		rb.velocity = new Vector2( movementSpeed * vel, rb.velocity.y );
	}
}
