using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(30,0,0);
    private float startDelay = 2;
    private float delayRate = 2;
    private PlayerController PlayerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, delayRate);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }
    void SpawnObstacle(){
        if (!PlayerControllerScript.gameOver) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }

    }
}
