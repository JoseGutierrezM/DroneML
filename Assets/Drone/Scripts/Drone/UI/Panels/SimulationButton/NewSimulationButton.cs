using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSimulationButton : SimulationButton
{ 
    protected override void OnButtonClicked()
    {
        simulationManager.SetUpSimulation();
    }
}