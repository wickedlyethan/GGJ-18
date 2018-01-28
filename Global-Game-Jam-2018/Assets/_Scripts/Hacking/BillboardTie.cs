using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardTie : MonoBehaviour {
	
	public HackingGame hackingGame;

	public GameObject billboard;
	public Material newTexture;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hackingGame.triggerBillboard) {
			billboard.GetComponent<MeshRenderer> ().material = newTexture;
		}
	}
}
