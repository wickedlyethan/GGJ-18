using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public BallController ballController;

	public GameObject pickup;
	public int pickupsAquired;
	public int pickupsNeeded;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pickup.transform.Rotate (new Vector3 (15, 45, 30) * Time.deltaTime);
	}
}
