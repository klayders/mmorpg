using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{


    public Transform playerTransform;
    private Vector3 cameraOffset;
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    private void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }

    // public GameObject player;
    // public float offsetX = 0;
    // public float offsetZ = 5;
    // public float playerVelocity = 5;
    // private float movementX;
    // private float movementZ;
    // void Update()
    // {
    //     movementX = player.transform.position.x + offsetX - transform.position.x;
    //     movementZ = player.transform.position.z + offsetZ - transform.position.z;
    //     
    //     transform.position += new Vector3(
    //         movementX * playerVelocity * Time.deltaTime,
    //         0,
    //         movementZ * playerVelocity * Time.deltaTime
    //         );
    // }    
}
