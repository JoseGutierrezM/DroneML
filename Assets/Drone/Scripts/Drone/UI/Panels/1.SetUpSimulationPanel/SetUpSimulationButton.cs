using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SetUpSimulationButton : UIButtonController
{
    protected SetUpSimulationPanel setUpPanel;
    protected override void Awake()
    {
        base.Awake();
        setUpPanel = GetComponentInParent<SetUpSimulationPanel>();
    }
}
