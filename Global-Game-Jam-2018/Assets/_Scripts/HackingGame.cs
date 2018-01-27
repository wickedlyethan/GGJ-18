using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingGame : MonoBehaviour {

	public InputField console;

	public string inputLine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			inputLine = console.text;
			Debug.Log (inputLine);
		}
	}
}
