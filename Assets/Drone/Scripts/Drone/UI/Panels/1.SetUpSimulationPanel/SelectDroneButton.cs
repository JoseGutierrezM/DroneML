using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDroneButton : SetUpSimulationButton
{
    protected override void OnButtonClicked()
    {
        setUpPanel.SetUpDrone();
    }
}
