using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEnvironment : MonoBehaviour
{
    /*void Awake()
    {
        SimulationManager.onStartSimulation += Activate;
        SimulationManager.onEndSimulation += Deactivate;
        gameObject.SetActive(false);
    }*/

    void Activate()
    {
        gameObject.SetActive(true);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}