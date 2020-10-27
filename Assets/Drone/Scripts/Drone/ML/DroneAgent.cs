using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class DroneAgent : Agent
{
    public Drone drone;

    [SerializeField] Vector3 droneInitialPosition = new Vector3(0, 50, 0);

    [SerializeField] DroneTarget target;

    [SerializeField] float distanceRequired = 6.5f;   

    public override void Initialize()
    {
        drone = GetComponent<Drone>();
        droneInitialPosition = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = droneInitialPosition;
        drone.SetInitialValues();
    }

    void Update()
    {
        if (transform.localPosition.y <= 0)
        {
            AddNegativeReward(0.01f);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);

        sensor.AddObservation(drone.droneRigidbody.velocity.y);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        //drone.MoveVertically(vectorAction[0]);
        //float distanceFromTarget = Mathf.Abs(transform.position.y - target.transform.position.y);
        // if (distanceFromTarget <= distanceRequired)
        drone.verticalInput = vectorAction[0];

        if (drone.Information.currentHeight < 2)
        {
            if (drone.Information.currentSpeed > drone.Information.landingVelocity && drone.Information.currentSpeed < 0)
            {
                Debug.Log("Succesful Message");
                AddPositiveReward(1);
                EndEpisode();
            }
        }

        if (transform.position.y < 0 || transform.position.y < target.transform.position.y || transform.position.y >= 90)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        //actionsOut[0] = Input.GetAxis("Vertical");
        //Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);  

        /*actionsOut[0] = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            actionsOut[0] = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            actionsOut[0] = -1;
        }*/

        if (Input.GetAxis("Vertical") != 0)
        {
            actionsOut[0] = Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);
        }
    }

    public void AddPositiveReward(float amount = 1.0f, bool isFinal = false)
    {
        //SetReward(amount);
        AddReward(amount);

        if (isFinal)
        {
            EndEpisode();
        }
    }

    public void AddNegativeReward(float amount = -0.01f)
    {
        AddReward(amount);

        EndEpisode();
    }
}