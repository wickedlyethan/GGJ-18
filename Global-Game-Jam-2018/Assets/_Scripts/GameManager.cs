﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	/* creates singleton pattern:
	public = anyone can see it
	static = anyone can access it */
	public static GameManager instance = null;

	// The Player
	public GameObject thePlayer;
	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
	private ReticleRaycast ReticleRaycast;

	[Header("Hacking Game")]
	public GameObject hackingCanvas;
	public HackingGame hackingGame;

	[Header("Sound Effects")]
	// public AudioSource Music_Source;
	public AudioSource SFX_Source;
	public AudioSource Result_Source;
	public AudioClip SuccessSFX;
	public AudioClip FailureSFX;
	public AudioClip[] SmashSFX;

	[Header("UI References")]
	// Pause Canvas
	public GameObject PauseCanvas;

 	[Header("Game Variables")]
 	// Public
 	[Header("Ad Hacking")]
 	public int hacksCompleted;
 	public GameObject[] AdsToHack;
 	public Material[] NewMaterials;
 	[Header("Poster Smashing")]
 	public float PosterCameraShake = 0.5f;
 	public int PostersThatExist;
 	public int PostersDestroyed;
 	[Header("Respawn")]
 	private Vector3 RespawnLocation;
	private Quaternion RespawnRotation; 
	public GameObject[] RespawnLocations;

 	// Private
	private bool isPaused = false;
	private bool canPause = true;

	/*****Defaults******/

	void Awake() {
		if (instance == null){instance = this;}
		else if (instance != this){Destroy(gameObject);}
		// DontDestroyOnLoad(gameObject);

		GetComponent<FadingInOut>().BeginFade(-1);

		/*References*/
		hackingGame = hackingCanvas.GetComponent<HackingGame>();
		controller = thePlayer.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
		ReticleRaycast = thePlayer.GetComponentInChildren<ReticleRaycast> ();

		/*Resets*/
		RespawnLocation = thePlayer.transform.position;
		RespawnRotation = thePlayer.transform.rotation;
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

	public void LaunchHack(Vector3 lastTerminal){
		// Set Respawn
		RespawnLocation = RespawnLocations[hacksCompleted].transform.position;
		RespawnRotation = RespawnLocations[hacksCompleted].transform.rotation;
		// Start Hacking Game
		hackingGame.Invoke ("CommenceHacking", 0f);
		hackingCanvas.SetActive (true);
		// Disable Player Controls, lock in hack screen
		DisablePlayerController(true);
		canPause = false;
		ReticleRaycast.enabled = false;
	}
	public void StopHacking(bool didWin) {
		hackingCanvas.SetActive (false);
		DisablePlayerController (false);
		if (didWin == true){
			AdsToHack[hacksCompleted - 1].GetComponent<MeshRenderer>().material = NewMaterials[hacksCompleted - 1];
		}
		// else if (didWin == false){PlayResultSound(false);}
		canPause = true;
		ReticleRaycast.enabled = true;
	}

	public void DestroyPoster(){
		PostersDestroyed++;
		controller.CameraShake.shakeDuration = PosterCameraShake;
		// Update UI to show progress
		// Success Sound
		PlaySFX(SmashSFX[Random.Range(0,SmashSFX.Length)]);
		PlayResultSound(true);
	}

	/*****Sound Management******/

	private void PlaySFX(AudioClip SFX){
		SFX_Source.clip = SFX;
		SFX_Source.Play();
	}

	public void PlayResultSound(bool success){
		if (success == true){Result_Source.clip = SuccessSFX;}
		else{Result_Source.clip = FailureSFX;}
		Result_Source.Play();
	}

	/*****Utility******/

	void pause(){
		if(canPause == true){
			PauseCanvas.SetActive(true);
			DisablePlayerController (true);
			isPaused = true;
			Time.timeScale = 0.5f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
	public void unPause(){
		PauseCanvas.SetActive(false);
		DisablePlayerController (false);
		isPaused = false;
		Time.timeScale = 1.0f;
	}

	public void DisablePlayerController (bool status){
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

	public void Respawn(){
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		thePlayer.transform.position = RespawnLocation;
		thePlayer.transform.rotation = RespawnRotation;
	}

	public void Restart(){
		Debug.Log("Restarting");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Quit(){
		Debug.Log("Quitting");
		Application.Quit();
	}
}
