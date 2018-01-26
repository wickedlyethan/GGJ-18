using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	/* creates singleton pattern:
	public = anyone can see it
	static = anyone can access it */
	public static GameManager instance = null;

	void Awake(){
		/* Singleton Shit */
		if (instance == null){instance = this;}
		else if (instance != this){Destroy(gameObject);}
		DontDestroyOnLoad(gameObject);
	}
}
