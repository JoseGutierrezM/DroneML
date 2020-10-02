using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDroneButton : SetUpSimulationButton
{
    protected override void OnButtonClicked()
    {
        setUpPanel.BackDrone();
    }
}
