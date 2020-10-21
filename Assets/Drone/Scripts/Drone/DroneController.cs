using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    Drone drone;

    [SerializeField] Vector3 droneInitialPosition = new Vector3( 0, 50, 0);

    void Awake()
    {
        drone = GetComponent<Drone>();
        SimulationManager.onSetUpSimulation += DeActivateDrone;
        SimulationManager.onStartSimulation += ActivateDrone;
        SimulationManager.onEndSimulation += DeActivateDrone;
    }

    void ActivateDrone()
    {
        transform.position = droneInitialPosition;
        drone.SetInitialValues();
        gameObject.SetActive(true);
    }

    void DeActivateDrone()
    {
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (!SimulationManager.GetInstance().SimulationMode)
        {
            VerticalMovement();
        }
    }

    void VerticalMovement()
    {
        float verticalInput = Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);

        drone.verticalInput = verticalInput;
        //drone.MoveVertically(verticalInput);
    }
} 
