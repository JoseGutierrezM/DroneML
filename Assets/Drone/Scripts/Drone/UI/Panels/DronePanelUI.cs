using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class DronePanelUI : MonoBehaviour
{
    DroneTraining droneTraining;
    public List<Drone> drones;
    protected Dictionary<string, DroneFieldUI> droneFieldsDictionary;
    protected SimulationManager simulationManager;

    protected virtual void Awake()
    {
        //drone = FindObjectOfType<Drone>(); 
        droneTraining = FindObjectOfType<DroneTraining>();
        drones = droneTraining.gameObject.GetComponentsInChildren<Drone>().ToList();
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