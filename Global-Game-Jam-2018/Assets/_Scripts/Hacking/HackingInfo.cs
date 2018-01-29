using UnityEngine;
using System.Collections;

[System.Serializable]
public class HackingInfo : ScriptableObject
{
	[Tooltip("Which hacking event is this?")]
	public int eventID;
	[Tooltip("This is where the commands the player has to enter go.")]
	public string[] PlayerCommands;
}