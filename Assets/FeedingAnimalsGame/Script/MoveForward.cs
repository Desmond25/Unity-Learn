using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
