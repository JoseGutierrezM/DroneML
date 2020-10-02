using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DronePanelUI : MonoBehaviour
{
    protected Drone drone;
    protected Dictionary<string, DroneFieldUI> droneFieldsDictionary;
    protected SimulationManager simulationManager;

    protected virtual void Awake()
    {
        drone = FindObjectOfType<Drone>(); 
        droneFieldsDictionary = new Dictionary<string, DroneFieldUI>();
        foreach (DroneFieldUI _element in GetComponentsInChildren<DroneFieldUI>(true))
        {
            if (!droneFieldsDictionary.ContainsKey(_element.GetDescription()))
            {
                droneFieldsDictionary.Add(_element.GetDescription(), _element);
            }
        }
        simulationManager = SimulationManager.GetInstance();
    }

    public abstract void UpdateDroneFieldsValues();
}