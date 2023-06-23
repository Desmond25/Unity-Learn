using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 15f;
    private float xRange = 10f;

    [SerializeField] private GameObject projectilePrefab;

    private void Update()
    {
        
        // Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }
}
