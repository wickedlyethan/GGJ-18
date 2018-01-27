using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleRaycast : MonoBehaviour {

/*Public*/

[TooltipAttribute("Use this variable to change how far away from them a player can reach!")]
public float raycastReach = 3;

public Image AspectRatio;

/* Private */
[SerializeField] private bool canClick;
private Ray theRay;
private GameObject currentObj;

void FixedUpdate() 
{	
	RaycastHit hit = new RaycastHit();

	if (Physics.Raycast(transform.position, transform.forward, out hit, raycastReach)){
		currentObj = hit.collider.gameObject;
		if (hit.collider.gameObject.tag == "Terminal" | hit.collider.gameObject.tag == "Poster"){
			AspectRatio.rectTransform.localScale = new Vector3(1,1,1);
			canClick = true;
		}
	}
	else {
			AspectRatio.rectTransform.localScale = new Vector3(1,1.35f,1);
			canClick = false;
		}
}
}