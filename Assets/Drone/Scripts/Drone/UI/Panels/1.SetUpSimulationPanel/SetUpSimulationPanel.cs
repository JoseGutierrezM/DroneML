using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpSimulationPanel : DronePanelUI
{
    List<DroneData> dronesData;
    int currentDrone;

    NextDroneButton nextDroneButton;
    BackDroneButton backDroneButton;

    protected override void Awake()
    {
        base.Awake();
        nextDroneButton = GetComponentInChildren<NextDroneButton>();
        backDroneButton = GetComponentInChildren<BackDroneButton>();
        LoadDronesData();
        currentDrone = 0;
        backDroneButton.gameObject.SetActive(false);
        SimulationManager.onSetUpSimulation += UpdateDroneFieldsValues;
    }

    void LoadDronesData()
    {
        dronesData = new List<DroneData>(Resources.LoadAll<DroneData>("Drones/"));
    }

    public void SetUpDrone()
    {
        foreach(Drone drone in drones)
        {
            drone.SetUpDrone(dronesData[currentDrone]);
        }
        simulationManager.InitializeSimulation();
    }

    public void NextDrone()
    {
        if(currentDrone < dronesData.Count - 1)
        {
            currentDrone++;
            backDroneButton.gameObject.SetActive(true);
            UpdateDroneFieldsValues();
            if (currentDrone == dronesData.Count - 1)
            {
                nextDroneButton.gameObject.SetActive(false);
            }
        }
    }

    public void BackDrone()
    {
        if (currentDrone > 0)
        {
            currentDrone--;
            nextDroneButton.gameObject.SetActive(true);
            UpdateDroneFieldsValues();
            if (currentDrone == 0)
            {
                backDroneButton.gameObject.SetActive(false);
            }
        }
    }

    public override void UpdateDroneFieldsValues()
    {
        droneFieldsDictionary[DroneFieldSetUpSimulation.Drone_Name.ToString()].SetValue(dronesData[currentDrone].name);
        droneFieldsDictionary[DroneFieldSetUpSimulation.Drone_Mass.ToString()].SetValue(dronesData[currentDrone].droneBodyData.droneMass.ToString("0.00"));
        droneFieldsDictionary[DroneFieldSetUpSimulation.Drag_Force.ToString()].SetValue(dronesData[currentDrone].droneBodyData.dragForce.ToString("0.00"));
        droneFieldsDictionary[DroneFieldSetUpSimulation.Max_Speed.ToString()].SetValue(dronesData[currentDrone].droneBodyData.maxVerticalSpeed.ToString("0.00"));
        droneFieldsDictionary[DroneFieldSetUpSimulation.Motor_Force.ToString()].SetValue(dronesData[currentDrone].droneMotorData.verticalForce.ToString("0.00"));
        droneFieldsDictionary[DroneFieldSetUpSimulation.Number_of_Motors.ToString()].SetValue(dronesData[currentDrone].droneMotorData.motorsQuantity.ToString());
    }
}