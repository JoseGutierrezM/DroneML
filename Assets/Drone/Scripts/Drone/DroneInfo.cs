using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DroneInfo 
{
    public float currentSpeed;
    public float currentHeight;

    public float landingVelocity = -10;
    public float verticalDistance = 0.5f;
}
