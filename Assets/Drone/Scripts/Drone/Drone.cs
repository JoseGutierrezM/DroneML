using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public static Action<bool> onLandingResult;

    Rigidbody droneRigidbody;
    DroneBodyData dronebodyData;
    List<DroneMotor> motors;
    public DroneInfo Information { get; private set; } 

    [SerializeField] LayerMask layer;
    public DroneState droneState;

    void Awake()
    {
        droneRigidbody = GetComponent<Rigidbody>();
        motors = GetComponentsInChildren<DroneMotor>().ToList();
        Information = new DroneInfo();
    }

    public void SetUpDrone(DroneData _droneData)
    {
        SetInitialValues();
        dronebodyData = _droneData.droneBodyData;
        droneRigidbody.mass = dronebodyData.droneMass;
        foreach (DroneMotor droneMotor in motors)
        {
            droneMotor.SetUpMotor(_droneData.droneMotorData, droneRigidbody);
        }
    }

    public void SetInitialValues()
    {
        Information.currentSpeed = 0;
        droneRigidbody.velocity = Vector3.zero;
        droneState = DroneState.Flying;
    }

    public void MoveVertically(float _verticalInput)
    {
        if(droneRigidbody.velocity.y < dronebodyData.maxSpeed)
        {
            foreach (DroneMotor droneMotor in motors)
            {
                droneMotor.ApplyVerticalForce(_verticalInput);
            }
        }

        Information.currentSpeed = droneRigidbody.velocity.y;
        Information.currentHeight = transform.position.y;

        if(Information.currentSpeed != 0)
        {
            VerifyHeight();
        }
    }

    void VerifyHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Information.verticalDistance, layer))
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.red, 1);
            droneState = DroneState.Crashing;
            onLandingResult?.Invoke(false);
        }
        else if (Physics.Raycast(transform.position, Vector3.down, out hit, Information.verticalDistance, layer))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.blue, 1);
            droneState = DroneState.Landing; 
            VerifyLanding();
        }
        else
        {
            droneState = DroneState.Flying;
        }
    }

    void VerifyLanding()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Information.verticalDistance, layer))
        {
            if(Information.currentSpeed > Information.landingVelocity && Information.currentSpeed < 0)
            {
                onLandingResult?.Invoke(true);
            }
            else
            {
                onLandingResult?.Invoke(false);
            }
        }
    }
}

public enum DroneState
{
    Flying, 
    Landing, 
    Crashing
}