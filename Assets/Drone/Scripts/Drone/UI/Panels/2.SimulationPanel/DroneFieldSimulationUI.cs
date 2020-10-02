using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFieldSimulationUI : DroneFieldUI
{
    public DroneFieldSimulation droneFieldInformation;

    public override string GetDescription()
    {
        return droneFieldInformation.ToString();
    }

    protected override void SetDescription()
    {
        droneFieldInfoDescription.SetLabel(droneFieldInformation.ToString().Replace('_', ' '));
    }
}

public enum DroneFieldSimulation
{
    Speed,
    Height,
    Drone_State
}