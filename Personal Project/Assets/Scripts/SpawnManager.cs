﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 12.0f;
    private float zPowerupRange = 4.0f;

    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy",startDelay,enemySpawnTime);
        InvokeRepeating("SpawnPowerup",startDelay,powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomEnemy(){
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, 0.75f, zEnemySpawn);
        GameObject enemyToSpawn = enemies[randomIndex]; 
        Instantiate(enemyToSpawn, spawnPos, enemyToSpawn.transform.rotation);
    }
    void SpawnPowerup(){
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, 0.75f, randomZ);
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
