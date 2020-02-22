using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 loodDirection = (player.transform.position - transform.position).normalized;

        // This is to follow the player normalized is for slow down de force applied in the vector
        enemyRb.AddForce(loodDirection * speed);
    }
}
