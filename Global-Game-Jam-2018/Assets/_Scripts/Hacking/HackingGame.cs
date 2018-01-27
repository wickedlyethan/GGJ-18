﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingGame : MonoBehaviour {

	public InputField consoleInput;
	public Text consoleText;
	public HackingInfo[] hackingInfo;

	public string inputLine;
	public float delay = 2.0f;

	[Header("Counters")]
	[SerializeField] private string tempLine;
	[SerializeField] private int hackingID;
	[SerializeField] private int hacksCompleted;
	[SerializeField] private int successCount;
	[SerializeField] private int chancesLeft = 3;
	// Use this for initialization
	void Start () {
		StartCoroutine ("LaunchGame", 0f);
	}
	
	// Update is called once per frame
	void Update () {
		successCount = Mathf.Clamp(successCount, 0, (hackingInfo[hackingID].PlayerCommands.Length));
		if (Input.GetKeyDown (KeyCode.Return)) {
			Hack ();
		}
		if (successCount == (hackingInfo [hackingID].PlayerCommands.Length)) {
			Debug.Log ("Hacking Complete");
			consoleText.text += ("\n" + "------------------" + "\n" + "HACKING COMPLETE" + "\n" + "------------------" + "\n");
			hackingID++;
			StartCoroutine ("LaunchGame", delay);

		}
	}
/*	void LaunchGame() {
		consoleText.text = (" ");
		successCount = Mathf.Clamp(successCount, 0, hackingInfo[hackingID].PlayerCommands.Length);
		consoleInput.Select ();
		consoleInput.ActivateInputField ();
		tempLine = hackingInfo [hackingID].PlayerCommands [successCount];
	}*/
	void Hack () {
		inputLine = consoleInput.text;
		if (inputLine == tempLine) {
			Debug.Log ("Comparison Success");
			consoleText.text += ("" + "\n" + inputLine + "\n" + "COMMAND SUCCESSFUL" + "\n");
			consoleInput.text = "";
			successCount++;
			tempLine = hackingInfo [hackingID].PlayerCommands [successCount];
		} else if (inputLine != tempLine) {
			consoleText.text += ("" + "\n" + inputLine + "\n" + "COMMAND NOT SUCCESSFUL" + "\n");
			consoleInput.text = "";
			chancesLeft--;
			if (chancesLeft == 0) {
				Debug.Log ("Hacking Failed");
			}
		}
		if (successCount == hackingInfo [hackingID].PlayerCommands.Length) {
			Debug.Log("Hacking Complete");
			consoleText.text += ("\n" + "---------------" + "\n" + "HACKING COMPLETE" + "\n" + "---------------" + "\n");
		}
		consoleInput.Select ();
		consoleInput.ActivateInputField ();
	}
	public IEnumerator LaunchGame (float delay) {
		yield return new WaitForSeconds (delay);
		consoleText.text = ("Hacking Game: " + (hackingID + 1));
		successCount = Mathf.Clamp(successCount, 0, hackingInfo[hackingID].PlayerCommands.Length);
		consoleInput.Select ();
		consoleInput.ActivateInputField ();
		tempLine = hackingInfo [hackingID].PlayerCommands [successCount];
	}
}
