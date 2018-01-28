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

	[Header("Hacking Game")]
	public GameObject hackingCanvas;
	public HackingGame hackingGame;

	// Pause Canvas
	public GameObject PauseCanvas;

 	[Header("Game Variables")]
 	// Public
 	// Hacking-Related

 	// Poster-Related
 	public float PosterCameraShake = 0.5f;
 	public int PostersThatExist;
 	public int PostersDestroyed;

 	// Private
	private bool isPaused;

	/*****Defaults******/

	void Awake() {
		if (instance == null){instance = this;}
		else if (instance != this){Destroy(gameObject);}
		DontDestroyOnLoad(gameObject);

		GetComponent<FadingInOut>().BeginFade(-1);

		/*References*/
		hackingGame = hackingCanvas.GetComponent<HackingGame> ();
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

	/*****Game Functions******/

	public void LaunchHack(){
		hackingGame.Invoke ("CommenceHacking", 0f);
		hackingCanvas.SetActive (true);
		DisablePlayerController(true);
	}
	public void StopHacking() {
		hackingCanvas.SetActive (false);
		DisablePlayerController (false);
	}

	public void DestroyPoster(){
		PostersDestroyed++;
		controller.CameraShake.shakeDuration = PosterCameraShake;
		// Update UI to show
	}

	/*****Utility******/

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
			//Cursor.visible = true;
			//Cursor.lockState = CursorLockMode.None;
			controller.enabled = false;
		}
		if (status == false){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			controller.enabled = true;
		}
	}

	public void Quit(){
		Application.Quit();
	}
}
