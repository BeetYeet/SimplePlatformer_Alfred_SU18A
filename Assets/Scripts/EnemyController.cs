using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	public float movementSpeed = 2f;
	bool moveLeft;
	private Rigidbody2D rb;
	public SpriteRenderer sr;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	public void Turn( bool left )
	{
		moveLeft = left;
		sr.flipX = left;
	}

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

	void Update () {
		Move( 1f );
	}

	private void Move( float vel )
	{
		rb.velocity = new Vector2( movementSpeed * vel * (moveLeft ? -1f : 1f), rb.velocity.y );
	}
}
