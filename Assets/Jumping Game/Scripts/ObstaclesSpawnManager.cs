using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25f, 0f, 0f);
    private float startDelay = 2f;
    private float repeatRate = 2f;
    private PlayerController playerControllerScript;


    private void Start()
    {

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

    }

    private void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }

}
