using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour {

	public float minspeed;
	public float maxspeed;

    void Start ()
    {
    	GetComponent<Rigidbody>().velocity = transform.forward * (Random.Range(minspeed,maxspeed));
        // GetComponent<rigidbody>().velocity = transform.forward * speed;
    }
}
