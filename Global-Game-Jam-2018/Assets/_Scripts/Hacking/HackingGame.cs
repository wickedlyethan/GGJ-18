using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingGame : MonoBehaviour {

	public InputField consoleInput;
	public Text consoleText;
	public HackingInfo[] eventID;

	public string inputLine;
	// Use this for initialization
	void Start () {
		consoleInput.Select ();
		consoleInput.ActivateInputField ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			inputLine = consoleInput.text;
			consoleInput.text = "";
			Debug.Log (inputLine);
			consoleText.text += (inputLine + "\n");
			consoleInput.Select ();
			consoleInput.ActivateInputField ();
		}
	}
}
