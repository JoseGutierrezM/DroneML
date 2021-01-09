using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSimulationPanel : DronePanelUI
{
    SuccessMessage successMessage;
    FailureMessage failureMessage;

    protected override void Awake()
    {
        base.Awake();
        successMessage = GetComponentInChildren<SuccessMessage>();
        failureMessage = GetComponentInChildren<FailureMessage>();
    }

    public void Success()
    {
        failureMessage.gameObject.SetActive(false);
        successMessage.gameObject.SetActive(true);
    }

    public void Failure()
    {
        successMessage.gameObject.SetActive(false);
        failureMessage.gameObject.SetActive(true);
    }

    public override void UpdateDroneFieldsValues()
    {
        throw new System.NotImplementedException();
    }
}
