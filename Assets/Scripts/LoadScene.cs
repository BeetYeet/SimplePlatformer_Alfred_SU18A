using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public string sceneName;

	// for loading a level with a custom level name (for when there could be more than one level to be loaded)
	public void Trigger(string level)
	{
		// load the level
		SceneManager.LoadScene( level );
	}

	// for loading the level in the sceneName variable (for when there will only be loaded one level)
	public void TriggerSimple()
	{
		// load the level
		SceneManager.LoadScene( sceneName );
	}
}
