using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMotor : MonoBehaviour
{
    [SerializeField] DroneMotorData droneMotorData;
    Rigidbody droneRigidbody;

    public void SetUpMotor(DroneMotorData _droneMotorData, Rigidbody _droneRigidbody)
    {
        droneMotorData = _droneMotorData;
        droneRigidbody = _droneRigidbody;
    }

    void FixedUpdate()
    {
        
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

    public void ApplyHorizontalForceX(float _horizontalInput)
    {
        float horizontalForceX = droneMotorData.horizontalForce;

        switch (droneMotorData.forceModeType)
        {
            case ForceModeType.Force:
                droneRigidbody.AddForceAtPosition(transform.right * horizontalForceX * _horizontalInput, transform.position, ForceMode.Force);
                break;
            case ForceModeType.Impulse:
                droneRigidbody.AddForceAtPosition(transform.right * horizontalForceX * _horizontalInput, transform.position, ForceMode.Impulse);
                break;
        }
    }

    public void ApplyHorizontalForceZ(float _horizontalInput)
    {
        float horizontalForceZ = droneMotorData.horizontalForce;

        switch (droneMotorData.forceModeType)
        {
            case ForceModeType.Force:
                droneRigidbody.AddForceAtPosition(transform.forward * horizontalForceZ * _horizontalInput, transform.position, ForceMode.Force);
                break;
            case ForceModeType.Impulse:
                droneRigidbody.AddForceAtPosition(transform.forward * horizontalForceZ * _horizontalInput, transform.position, ForceMode.Impulse);
                break;
        }
    }
}