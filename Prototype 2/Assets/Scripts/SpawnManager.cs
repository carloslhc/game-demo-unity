using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    // CTRL + Llave izquierda para documentacion de metodos
    void Start()
    {
        // los parametros de este metodo son el nombre del metodo a repetir en string, el tiempo en que empieza y el intervalo.
        InvokeRepeating("SpawnRandomAnimal",startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // if ( Input.GetKeyDown( KeyCode.S ) || Input.GetButtonDown("B") ) {
        //    SpawnRandomAnimal();
        // }
    }
    
    void SpawnRandomAnimal() {


            int animalIndex = Random.Range( 0, animalPrefabs.Length );
        
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX), 0, spawnPosZ );

            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation );
    }

}
