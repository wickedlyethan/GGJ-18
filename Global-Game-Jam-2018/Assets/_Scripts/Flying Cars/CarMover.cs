using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour {

	public float speed;

    void Start ()
    {
    	GetComponent<Rigidbody>().velocity = transform.forward * speed;
        // GetComponent<rigidbody>().velocity = transform.forward * speed;
    }
}
