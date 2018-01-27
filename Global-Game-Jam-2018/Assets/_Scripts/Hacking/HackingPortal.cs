using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingPortal : MonoBehaviour {

	void OnMouseUpAsButton(){
		Debug.Log("I am a hacking portal!");
		// Launch hacking mini-game, preferably not through here
		// GameManager.instance.LaunchHack() or similar
	}
}
