using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMotor : MonoBehaviour
{
    DroneMotorData droneMotorData;
    Rigidbody droneRigidbody;

    public void SetUpMotor(DroneMotorData _droneMotorData, Rigidbody _droneRigidbody)
    {
        droneMotorData = _droneMotorData;
        droneRigidbody = _droneRigidbody;
    }

    public void ApplyVerticalForce(float _verticalInput)
    {
        float verticalForce = droneMotorData.verticalForce;

        switch (droneMotorData.forceModeType)
        {
            case ForceModeType.Force:
                droneRigidbody.AddForceAtPosition(transform.up * verticalForce * _verticalInput, transform.position, ForceMode.Force);
                break;
            case ForceModeType.Impulse:
                droneRigidbody.AddForceAtPosition(transform.up * verticalForce * _verticalInput, transform.position, ForceMode.Impulse);
                break;
        }
    }
}
