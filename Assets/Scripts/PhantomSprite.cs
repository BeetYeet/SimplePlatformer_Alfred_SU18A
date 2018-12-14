using UnityEngine;
public class PhantomSprite: MonoBehaviour
{
	void Awake()
	{
		// stop rendering the sprite on this gameobject
		this.GetComponent<SpriteRenderer>().enabled = false;
	}
}
