using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleRaycast : MonoBehaviour {

/*Public*/

[TooltipAttribute("Use this variable to change how far away from them a player can reach!")]
public float raycastReach = 3;

// Aspect Ratio
public Image AspectRatio;
private Vector3 AspectRatioOn = new Vector3(1,1,1);
private Vector3 AspectRatioOff = new Vector3(1,1.35f,1);

[Header("Reticles")]
public GameObject AnarchyReticle;
public GameObject HackingReticle;

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
			ChangeReticle(hit.collider.gameObject.tag);
		}
	}
	else {
			AspectRatio.rectTransform.localScale = AspectRatioOff;
			canClick = false;
			ChangeReticle(null);
		}

	// Actual clicking on object
	if (canClick == true && Input.GetButtonDown("Fire1")){
		Click(hit.collider.gameObject.tag);
	}
}
private void ChangeReticle(string Reticle){
	switch (Reticle){
		case "Terminal":
			if(HackingReticle.activeSelf == false){HackingReticle.SetActive(true);}
			break;
		case "Poster":
			if(AnarchyReticle.activeSelf == false){AnarchyReticle.SetActive(true);}
			break;
		case null:
			HackingReticle.SetActive(false);
			AnarchyReticle.SetActive(false);
			break;
	}
}
private void Click(string thisTag){
	switch (thisTag){
			case "Terminal":
				AspectRatio.rectTransform.localScale = AspectRatioOff;
				GameManager.instance.LaunchHack(currentObj.transform.position);
				break;
			case "Poster":
				AspectRatio.rectTransform.localScale = AspectRatioOff;
				GameObject.Destroy(currentObj);
				GameManager.instance.DestroyPoster();
				break;
		}
	}
}