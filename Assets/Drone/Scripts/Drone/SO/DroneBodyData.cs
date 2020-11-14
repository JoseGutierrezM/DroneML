using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DroneBodyData : ScriptableObject
{
    [Range(0.1f, 25)]
    public float droneMass;
    
    [Range(0.1f, 25)]
    public float dragForce;

    [Range(1, 50)]
    public float maxVerticalSpeed;

    [Range(1, 50)]
    public float maxHorizontalSpeed;
}