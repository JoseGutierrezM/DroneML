using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSimulationButton : SimulationButton
{
    protected override void OnButtonClicked()
    {
        simulationManager.EndSimulation();
    }
}