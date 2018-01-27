using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleRaycast : MonoBehaviour {

/*Public*/

[TooltipAttribute("Use this variable to change how far away from them a player can reach!")]
public float raycastReach = 3;

public Image AspectRatio;
private Vector3 AspectRatioOn = new Vector3(1,1,1);
private Vector3 AspectRatioOff = new Vector3(1,1.35f,1);

/* Private */
[SerializeField] private bool canClick;
private Ray theRay;
private GameObject currentObj;

void FixedUpdate() 
{	
	// Raycast to see if Player is looking at important object
	RaycastHit hit = new RaycastHit();
	if (Physics.Raycast(transform.position, transform.forward, out hit, raycastReach)){
		currentObj = hit.collider.gameObject;
		if (hit.collider.gameObject.tag == "Terminal" | hit.collider.gameObject.tag == "Poster"){
			AspectRatio.rectTransform.localScale = AspectRatioOn;
			canClick = true;
		}
	}
	else {
			AspectRatio.rectTransform.localScale = AspectRatioOff;
			canClick = false;
		}

	// Actual clicking on object
	if (canClick == true && Input.GetButtonDown("Fire1")){
		switch (hit.collider.gameObject.tag){
			case "Terminal":
				AspectRatio.rectTransform.localScale = AspectRatioOff;
				// GameManager.instance.LaunchHack();
				break;
			case "Poster":
				AspectRatio.rectTransform.localScale = AspectRatioOff;
				// Destroy Poster, tell GameManager so it keeps track of how many Posters you've destroyed
				break;
		}
	}
}

}