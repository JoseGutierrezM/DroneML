using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DroneMotorData : ScriptableObject
{
    [Range(5, 20)]
    public float verticalForce;

    [Range(5, 20)]
    public float horizontalForce;

    [Range(2, 8)]
    public int motorsQuantity;

    public ForceModeType forceModeType;
}

public enum ForceModeType
{
    Force,
    Impulse
}