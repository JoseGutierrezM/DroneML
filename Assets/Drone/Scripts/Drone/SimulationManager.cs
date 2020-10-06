using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoSingleton<SimulationManager>
{
    public static Action onSetUpSimulation;
    public static Action onStartSimulation;
    public static Action onEndSimulation;

    public SimulationState simulationState;
    public bool IsAgentActive;

    protected override void Awake()
    {
        SetUpSimulation();
    }

    public void SetUpSimulation()
    {
        simulationState = SimulationState.SetUpSimulation;
        onSetUpSimulation?.Invoke();
    }

    public void InitializeSimulation()
    {
        simulationState = SimulationState.Simulation;
        onStartSimulation?.Invoke();
    }

    public void EndSimulation()
    {
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