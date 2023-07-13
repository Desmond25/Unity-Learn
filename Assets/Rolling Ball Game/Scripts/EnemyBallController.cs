using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallController : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody enemyRb;
    private GameObject player;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(directionToPlayer * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
