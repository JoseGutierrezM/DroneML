using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartSimulationButton : SimulationButton
{
    protected override void OnButtonClicked()
    {
        simulationManager.InitializeSimulation();
    }
}