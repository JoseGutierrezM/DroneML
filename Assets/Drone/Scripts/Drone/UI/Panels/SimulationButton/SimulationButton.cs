using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimulationButton : UIButtonController
{
    protected SimulationManager simulationManager;

    protected override void Awake()
    {
        base.Awake();
        simulationManager = SimulationManager.GetInstance();
    }
}
