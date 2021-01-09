using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DroneInfo 
{
    public float currentSpeed;
    public float currentHeight;
    public float distanceToTarget = 50;

    public float landingVelocity = -10;
    public float verticalDistance = 1.5f;
}
