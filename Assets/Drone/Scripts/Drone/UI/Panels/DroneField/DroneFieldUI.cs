using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DroneFieldUI : MonoBehaviour
{
    protected DroneFieldDescriptionUI droneFieldInfoDescription;
    DroneFieldValueUI droneFieldInfoValue;

    void Awake()
    {
        droneFieldInfoDescription = GetComponentInChildren<DroneFieldDescriptionUI>();
        droneFieldInfoValue = GetComponentInChildren<DroneFieldValueUI>();
    }

    void Start()
    {
        SetDescription();
    }

    public void SetValue(string _value)
    {
        droneFieldInfoValue.SetLabel(_value);
    }

    public abstract string GetDescription();

    protected abstract void SetDescription();
}