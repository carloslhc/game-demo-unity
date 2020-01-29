using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    public Rigidbody playerRb;
    private float zTopLimit = 9.8f;
    private float zBottomLimit = -1.5f; 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstraintPlayerPosition();
       
    }

    // Moves the player based on arrow key input
    void MovePlayer(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }
    // prevent the player from leaving top or bottom of the screen
    void ConstraintPlayerPosition() {
        if ( transform.position.z < zBottomLimit) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottomLimit);
        } else if ( transform.position.z > zTopLimit) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopLimit);
        }
    }
}
