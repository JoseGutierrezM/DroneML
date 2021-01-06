using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoSingleton<SimulationManager>
{
    public static Action onSetUpSimulation;
    public static Action onStartSimulation;
    public static Action onEndSimulation;

    [SerializeField] DroneCamera droneCamera;
    public SimulationState simulationState;
    public bool SimulationMode;

    protected override void Awake()
    {
        droneCamera = Camera.main.GetComponent<DroneCamera>();
        SetUpSimulation();
    }

    public void SetUpSimulation()
    {
        simulationState = SimulationState.SetUpSimulation;
        onSetUpSimulation?.Invoke();
    }

    public void InitializeSimulation()
    {
        droneCamera.StartCameraMovement();
        simulationState = SimulationState.Simulation;
        onStartSimulation?.Invoke();
    }

    public void EndSimulation()
    {
        droneCamera.StopCameraMovement();
        simulationState = SimulationState.EndSimulation;
        onEndSimulation?.Invoke();
    }
}

public enum SimulationState
{
    SetUpSimulation,
    Simulation,
    EndSimulation
}