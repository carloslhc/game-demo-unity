using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup = false;
    public float speed;
    public GameObject powerupIndicator;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerUpStrength = 15.0f;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point"); // usar esto para buscar un gameobject de la escena
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        // playerRb.AddForce(Vector3.forward * speed * forwardInput);


        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Powerup")){
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    // para mas informacion este link punto 6 en el video explica el metodo: https://learn.unity.com/tutorial/lesson-4-3-powerup-and-countdown?courseId=5cf96c41edbc2a2ca6e8810f&projectId=5cf96846edbc2a2bcde6d0fc#5ce379ecedbc2a2e52df6154
    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }

}
