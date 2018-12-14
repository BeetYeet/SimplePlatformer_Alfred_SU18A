using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnPlayerTouch : MonoBehaviour {

	[SerializeField]
	public SimpleEvent OnTriggered;

	// on colliding with an entity
	private void OnCollisionEnter2D( Collision2D collision )
	{
		// if the entity has a tag of "Player"
		if ( OnTriggered != null && collision.collider.tag == "Player" )
		{
			// call the event
			OnTriggered.Invoke();
		}
	}

	// on an entity entering the trigger
	private void OnTriggerEnter2D( Collider2D collision )
	{
		// if the entity has a tag of "Player"
		if ( OnTriggered != null && collision.tag == "Player" )
		{
			// call the event
			OnTriggered.Invoke();
		}
	}
}