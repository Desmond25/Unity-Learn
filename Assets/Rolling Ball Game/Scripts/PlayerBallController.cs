using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    [SerializeField] private GameObject powerupIndicator;
    private Rigidbody playerRb; 
    private GameObject focalPoint;
    private float speed = 5f;
    private float powerupStrength = 15f;
    private bool hasPowerup = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.55f, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        hasPowerup = true;
        powerupIndicator.SetActive(true);
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownRoutine());
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {

            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayerDir = other.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayerDir * powerupStrength, ForceMode.Impulse);

        }
    }
}
