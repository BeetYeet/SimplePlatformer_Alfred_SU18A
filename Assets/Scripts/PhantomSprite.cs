using UnityEngine;
public class PhantomSprite: MonoBehaviour
{
	void Awake()
	{
		this.GetComponent<SpriteRenderer>().enabled = false;
	}
}
