using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	/* creates singleton pattern:
	public = anyone can see it
	static = anyone can access it */
	public static GameManager instance = null;

	// The Player
	public GameObject thePlayer;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

	// Pause Canvas
	public GameObject PauseCanvas;

 	// Variables
	private bool isPaused; 

	void Awake() {
		if (instance == null){instance = this;}
		else if (instance != this){Destroy(gameObject);}
		DontDestroyOnLoad(gameObject);

		/*References*/
		controller = thePlayer.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

		/*Resets*/
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)|Input.GetKeyDown(KeyCode.P)){
			if(isPaused == false){
				pause();
			}
			else {
				unPause();
			}
		}
	}

	void pause(){
		PauseCanvas.SetActive(true);
		DisablePlayerController (true);
		isPaused = true;
		Time.timeScale = 0.5f;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	void unPause(){
		PauseCanvas.SetActive(false);
		DisablePlayerController (false);
		isPaused = false;
		Time.timeScale = 1.0f;
	}

	public void DisablePlayerController(bool status){
		if (status == true){
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			controller.enabled = false;
		}
		if (status == false){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			controller.enabled = true;
		}
	}
}
