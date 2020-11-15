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

    public void ApplyForce(Vector3 _inputForce)
    {
        Vector3 dir = new Vector3(_inputForce.x * droneMotorData.horizontalForce, _inputForce.y * droneMotorData.verticalForce, _inputForce.z * droneMotorData.horizontalForce);
        
        switch (droneMotorData.forceModeType)
        {
            case ForceModeType.Force:
                droneRigidbody.AddForceAtPosition(dir, transform.position, ForceMode.Force);
                break;
            case ForceModeType.Impulse:
                droneRigidbody.AddForceAtPosition(dir, transform.position, ForceMode.Impulse);
                break;
        }
    }
}