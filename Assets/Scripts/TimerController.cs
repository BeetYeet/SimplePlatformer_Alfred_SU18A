using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour {

	TextMeshProUGUI GUI;

	// Use this for initialization
	void Start () {
		GUI = this.GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
		GUI.text = Time.time.ToString("F3");
	}
}
