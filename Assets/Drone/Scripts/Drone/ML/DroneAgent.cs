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

    [SerializeField] int timer = 0;

    public float timeReward = -0.01f;
    float distanceReward = 0.01f;
    float currentDistance;

    public override void Initialize()
    {
        drone = GetComponent<Drone>();
        droneInitialPosition = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = droneInitialPosition;
        drone.SetInitialValues();
        timer = 0;
        currentDistance = 100;
    }

    void FixedUpdate()
    {
        timer++;
        if (drone.Information.distanceToTarget < currentDistance)
        {
            AddReward(distanceReward);
            //currentDistance = drone.Information.distanceToTarget;
        }
        else if (drone.Information.distanceToTarget > currentDistance)
        {
            AddReward(-distanceReward * 2);
        }
        currentDistance = drone.Information.distanceToTarget;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);

        sensor.AddObservation(target.transform.localPosition);

        sensor.AddObservation(drone.droneRigidbody.velocity);

        sensor.AddObservation(Vector3.Distance(transform.localPosition, target.transform.localPosition));
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        drone.verticalInputY = vectorAction[0]; 
        drone.horizontalInputX = vectorAction[1];
        drone.horizontalInputZ = vectorAction[2];

        AddReward(-1f / MaxStep);
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Vertical");
        actionsOut[1] = Input.GetAxis("HorizontalZ");
        actionsOut[2] = Input.GetAxis("HorizontalX");
    }

    public void AddPositiveReward(float amount = 1.0f)
    {
        AddReward(amount);
        EndEpisodeTimer();
    }

    public void AddNegativeReward(float amount = -0.01f)
    {
        AddReward(amount);
        EndEpisodeTimer();
    }

    public void EndEpisodeTimer()
    {
        //AddReward(timer * timeReward);
        /*float distanceToTarget = Vector3.Distance(transform.position, target.gameObject.transform.position);
        AddReward((100 - distanceToTarget) * distanceReward);*/
        EndEpisode();
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Environment"))
        { 

        }
    }*/
}