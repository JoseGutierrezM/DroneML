using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationPanel : DronePanelUI
{
    protected override void Awake()
    {
        base.Awake();
        Drone.onDroneMove += UpdateDroneFieldsValues;
    }

    public override void UpdateDroneFieldsValues()
    {
        droneFieldsDictionary[DroneFieldSimulation.Speed.ToString()].SetValue(drone.Information.currentSpeed.ToString("0.00"));
        droneFieldsDictionary[DroneFieldSimulation.Height.ToString()].SetValue(drone.Information.currentHeight.ToString("0.00"));
        droneFieldsDictionary[DroneFieldSimulation.Drone_State.ToString()].SetValue(drone.droneState.ToString());
    }
}
