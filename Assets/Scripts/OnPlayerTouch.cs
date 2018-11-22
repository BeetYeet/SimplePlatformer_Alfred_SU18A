using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnPlayerTouch : MonoBehaviour {

	[SerializeField]
	public SimpleEvent OnTriggered;
	private void OnCollisionEnter2D( Collision2D collision )
	{
		if ( OnTriggered != null && collision.collider.tag == "Player" )
		{
			OnTriggered.Invoke();
		}
	}
	private void OnTriggerEnter2D( Collider2D collision )
	{
		if ( OnTriggered != null && collision.tag == "Player" )
		{
			OnTriggered.Invoke();
		}
	}
}