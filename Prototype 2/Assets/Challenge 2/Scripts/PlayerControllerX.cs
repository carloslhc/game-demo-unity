using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnInterval = 1f;
    private float nextSpawnTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawnTime)
        {
            // explicacion: chequeo que el tiempo sea mayor a mi tiempo del siguiente spawneo y 
            // despues le sumo al siguiente spawneo el tiempo actual mas 1 segundo (este siendo el intervalo de spawn)
            nextSpawnTime = Time.time + spawnInterval;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
