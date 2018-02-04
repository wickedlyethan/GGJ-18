using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingGame : MonoBehaviour {

	public InputField consoleInput;
	public Text consoleText;
	public Text HelpText;
	public HackingInfo[] hackingInfo;

	public string inputLine;
	public float delay = 2.0f;

	[Header("Counters")]
	[SerializeField] private string tempLine;
	[SerializeField] private int hackingID;
	[SerializeField] private int successCount;
	[SerializeField] private int chancesLeft = 3;
	[HideInInspector] public Coroutine currentdelay = null;

	public void CommenceHacking () {
		successCount = Mathf.Clamp(0, 0, hackingInfo[hackingID].PlayerCommands.Length);
		chancesLeft = 3;
		PrepareGame ();
	}
	
	// Update is called once per frame
	void Update () {
		successCount = Mathf.Clamp(successCount, 0, (hackingInfo[hackingID].PlayerCommands.Length));
		if (Input.GetKeyDown (KeyCode.Return)) {
			Hack ();
		}
		if (successCount == (hackingInfo [hackingID].PlayerCommands.Length)) {
			HackSuccess();
		}
		if (chancesLeft == 0) {
			HackFail();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameManager.instance.StopHacking(false);
		}
	}
	
	/*void LaunchGame() {
		consoleText.text = (" ");
		successCount = Mathf.Clamp(successCount, 0, hackingInfo[hackingID].PlayerCommands.Length);
		consoleInput.Select ();
		consoleInput.ActivateInputField ();
		tempLine = hackingInfo [hackingID].PlayerCommands [successCount];
	}*/

	public void PrepareGame () {
		consoleText.text = ("Hacking Game: " + (hackingID + 1));
		tempLine = hackingInfo [hackingID].PlayerCommands [successCount];
		HelpTextDisplay();
		consoleInput.Select ();
		consoleInput.ActivateInputField ();
	}
	private void HelpTextDisplay(){
		HackingInfo temp = hackingInfo [hackingID];
		string Help = "AVAILABLE COMMANDS:" + "\n";
		for (int i = 0; i < temp.PlayerCommands.Length; i++){
			Help += temp.PlayerCommands[i];
			Help += "\n";
		}
		HelpText.text = Help;
	}

	private void Hack () {
		inputLine = consoleInput.text;
		if (inputLine == tempLine) {
			GameManager.instance.PlayResultSound(true);
			// Debug.Log ("Comparison Success");
			consoleText.text += ("" + "\n" + inputLine + "\n" + "COMMAND SUCCESSFUL" + "\n");
			consoleInput.text = "";
			successCount++;
			if (successCount == hackingInfo [hackingID].PlayerCommands.Length) {
				// Debug.Log ("Hacking Complete");
				// consoleText.text += ("\n" + "---------------" + "\n" + "HACKING COMPLETE" + "\n" + "---------------" + "\n");
			} else {
				tempLine = hackingInfo [hackingID].PlayerCommands [successCount];
			}
		} else if (inputLine != tempLine) {
			GameManager.instance.PlayResultSound(false);
			consoleText.text += ("" + "\n" + inputLine + "\n" + "COMMAND NOT SUCCESSFUL" + "\n");
			consoleInput.text = "";
			chancesLeft--;
		}
		consoleInput.Select ();
		consoleInput.ActivateInputField ();
	}

	private void HackSuccess(){
		// Debug.Log ("Hacking Complete");
		consoleText.text += ("\n" + "------------------" + "\n" + "HACKING COMPLETE" + "\n" + "------------------" + "\n");
		hackingID++;
		GameManager.instance.hacksCompleted++;
		if (GameManager.instance.hacksCompleted == GameManager.instance.AdsToHack.Length){DisplayWin();}
		else{currentdelay = StartCoroutine (ExitDelay());}
	}
	private IEnumerator ExitDelay () {
		yield return new WaitForSeconds (delay);
		GameManager.instance.StopHacking(true);
	}
	private void HackFail(){
		Debug.Log ("Hacking Failed");
		GameManager.instance.PlayResultSound(false);
		consoleText.text += ("\n" + "------------------" + "\n" + "HACKING FAILED" + "\n" + "------------------" + "\n");
		GameManager.instance.StopHacking(false);
	}
	public void DisplayWin(){
		consoleText.text += ("\n" + "---------------" + "\n" + "MISSION COMPLETE!!" + "\n" + "---------------" + "\n");
		consoleText.text += ("\n" + "You'll now leave the Terminal." + "\n" + "Press ESC again to leave the world.");
		consoleText.text += ("\n" + "But feel free to stay, you've made it a lot prettier ;D");
		delay = 5.0f;
		StartCoroutine(ExitDelay());
	}
}
