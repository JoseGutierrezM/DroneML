using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFieldSetUpSimulationUI : DroneFieldUI
{
    public DroneFieldSetUpSimulation droneFieldSetUp;

    public override string GetDescription()
    {
        return droneFieldSetUp.ToString();
    }

    protected override void SetDescription()
    {
        droneFieldInfoDescription.SetLabel(droneFieldSetUp.ToString().Replace('_', ' '));
    }
}

public enum DroneFieldSetUpSimulation
{
    Drone_Name,
    Drone_Mass,
    Drag_Force,
    Max_Speed,
    Motor_Force,
    Number_of_Motors
}