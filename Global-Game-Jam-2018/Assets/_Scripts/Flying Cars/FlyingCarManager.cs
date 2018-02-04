using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCarManager : MonoBehaviour {

	public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start ()
    {
        StartCoroutine (SpawnWaves ());
        spawnValues = transform.position;
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
            	// Vector3 spawnPosition = spawnValues;
                Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range ((spawnValues.y - 5), (spawnValues.y + 5)), Random.Range ((spawnValues.z - 15), (spawnValues.z + 15)));
                Quaternion spawnRotation = transform.rotation;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
        }
    }
}
