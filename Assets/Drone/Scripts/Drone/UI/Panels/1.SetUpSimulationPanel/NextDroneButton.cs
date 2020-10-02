using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDroneButton : SetUpSimulationButton
{
    protected override void OnButtonClicked()
    {
        setUpPanel.NextDrone();
    }
}
