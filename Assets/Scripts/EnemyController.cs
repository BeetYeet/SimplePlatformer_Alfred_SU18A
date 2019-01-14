using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	public float movementSpeed = 2f;
	private bool moveLeft;
	public bool flip = false;
	private Rigidbody2D rb;
	public SpriteRenderer sr;

	void Start () {
		// cashe the rigidbody
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// for switching direction
	public void Turn( bool left )
	{
		// set what direction to move
		moveLeft = left;
		// set what direction to face (the left variable is XORed with flip so that you can switch the direction of the sprite easely)
		sr.flipX = left ^ flip;
	}

	// all the functions below are for switching directions:

	public void TouchTopLeft()
	{
		Turn( false );
	}
	public void TouchTopRight()
	{
		Turn( true );
	}
	public void TouchBottomLeft()
	{
		Turn( false );
	}
	public void TouchBottomRight()
	{
		Turn( true );
	}


	// called once per frame
	void Update () {
		// trigger the movement
		Move( );
	}

	// function to recalculate the proper velocity of the enemy
	private void Move( )
	{
		// calculate a suitable velocity and make sure its to the correct direction
		rb.velocity = new Vector2( movementSpeed * (moveLeft ? -1f : 1f), rb.velocity.y );
	}
}
