using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public static Action onDroneMove;
    public static Action<bool> onLandingResult;

    public Rigidbody droneRigidbody;
    [SerializeField] DroneBodyData dronebodyData;
    [SerializeField] List<DroneMotor> motors;
    public DroneInfo Information { get; private set; } 

    [SerializeField] LayerMask layer;
    public DroneState droneState;

    [SerializeField] Vector3 droneInitialPosition = new Vector3(0, 50, 0);

    public float verticalInputY;
    public float horizontalInputX;
    public float horizontalInputZ;

    void Awake()
    {
        droneRigidbody = GetComponent<Rigidbody>();
        motors = GetComponentsInChildren<DroneMotor>().ToList();
        droneInitialPosition = transform.position;
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
        verticalInputY = horizontalInputX = horizontalInputZ = 0;
        transform.position = droneInitialPosition;
        droneRigidbody.angularVelocity = Vector3.zero;
        droneRigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);

        Information.currentSpeed = 0;
        Information.currentHeight = transform.position.y;
        droneState = DroneState.Flying;
        onDroneMove?.Invoke();
    }

    void FixedUpdate()
    {
        if (!SimulationManager.GetInstance().SimulationMode)
        {
            verticalInputY = Input.GetAxis("Vertical");
            horizontalInputX = Input.GetAxis("HorizontalX");
            horizontalInputZ = Input.GetAxis("HorizontalZ");
        }

        Vector3 input = new Vector3(horizontalInputX, verticalInputY, horizontalInputZ);
        MoveDrone(input);

        var velocity = droneRigidbody.velocity;

        velocity.x = Mathf.Clamp(velocity.x, -dronebodyData.maxHorizontalSpeed, dronebodyData.maxHorizontalSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -dronebodyData.maxVerticalSpeed, dronebodyData.maxVerticalSpeed);
        velocity.z = Mathf.Clamp(velocity.z, -dronebodyData.maxHorizontalSpeed, dronebodyData.maxHorizontalSpeed);

        droneRigidbody.velocity = velocity;

        Information.currentSpeed = droneRigidbody.velocity.y;
        Information.currentHeight = transform.position.y;
    }

    void MoveDrone(Vector3 _inputForce)
    {
        foreach (DroneMotor droneMotor in motors)
        {
            droneMotor.ApplyForce(_inputForce);
        }
    }

    void VerifyHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Information.verticalDistance, layer))
        {
            Debug.DrawRay(transform.position, Vector3.up, Color.red, 1);
            droneState = DroneState.Crashing;
            Information.distanceToTarget = Vector3.Distance(transform.position, hit.transform.position);
            //onLandingResult?.Invoke(false);
        }
        else if (Physics.Raycast(transform.position, Vector3.down, out hit, Information.verticalDistance, layer))
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.blue, 1);
            droneState = DroneState.Landing;
            Information.distanceToTarget = Vector3.Distance(transform.position, hit.transform.position);
            //VerifyLanding();
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
    Idle,
    MoveUp,
    MoveDown,
    Flying, 
    Landing, 
    Crashing
}