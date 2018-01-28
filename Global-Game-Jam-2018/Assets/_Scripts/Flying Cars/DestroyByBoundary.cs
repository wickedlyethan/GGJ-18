using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
    	if(other.gameObject == GameManager.instance.thePlayer){
    		GameManager.instance.ReloadLevel();
    	}
        Destroy(other.gameObject);
    }
}