using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFieldEndSimulationUI : DroneFieldUI
{
    public DroneFieldEndSimulation droneFieldResults;

    public override string GetDescription()
    {
        return droneFieldResults.ToString();
    }

    protected override void SetDescription()
    {
        droneFieldInfoDescription.SetLabel(droneFieldResults.ToString().Replace('_', ' '));
    }
}

public enum DroneFieldEndSimulation
{

}