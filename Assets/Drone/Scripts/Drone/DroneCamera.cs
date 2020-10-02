using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamera : MonoBehaviour
{
    [SerializeField] Transform drone;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 2, -5);
    float smooth = 0.15f;

    void Awake()
    {
        drone = FindObjectOfType<Drone>().transform;
    }

    void FixedUpdate()
    {
        Vector3 adjustedPosition = drone.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, adjustedPosition, smooth);
        transform.position = smoothedPosition;
    }

    public void StartCameraMovement()
    {

    }

    public void StopCameraMovement()
    {

    }
}
