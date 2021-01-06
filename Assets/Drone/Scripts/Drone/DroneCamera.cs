using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamera : MonoBehaviour
{
    [SerializeField] Transform drone;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 2, -5);
    [SerializeField] Camera cam;
    float smooth = 0.15f;
    bool canMove;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 adjustedPosition = drone.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, adjustedPosition, smooth);
            transform.position = smoothedPosition;
        }
    }

    public void StartCameraMovement()
    {
        canMove = true;
        cam.fieldOfView = 85;
    }

    public void StopCameraMovement()
    {
        canMove = false;
        cam.fieldOfView = 50;
    }
}
