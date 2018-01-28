using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
    	if(other.gameObject.tag == "Player"){
    		GameManager.instance.Respawn();
    	}
        else{Destroy(other.gameObject);}
    }
}