using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class DroneAgent : Agent
{
    Drone drone;

    [SerializeField] Vector3 droneInitialPosition = new Vector3(0, 50, 0);

    [SerializeField] DroneTarget target;

    [SerializeField] float distanceRequired = 2.5f;   

    public override void Initialize()
    {
        drone = GetComponent<Drone>();
        //droneInitialPosition = transform.localPosition;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = droneInitialPosition;
        drone.SetInitialValues();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);

        sensor.AddObservation(drone.droneRigidbody.velocity.y);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        drone.MoveVertically(vectorAction[0]);
        float distanceFromTarget = Mathf.Abs(transform.position.y - target.transform.position.y);
        if (distanceFromTarget < distanceRequired)
        {
            AddReward(1);
            EndEpisode();
            Debug.LogWarning("Success message");
            if (drone.Information.currentSpeed > drone.Information.landingVelocity && drone.Information.currentSpeed < 0)
            {
                AddReward(1);
                EndEpisode();
                Debug.LogWarning("Success message");
            }
        }
        if (transform.position.y < 0 || transform.position.y < target.transform.position.y || transform.position.y >= 90)
        {
            EndEpisode();
            Debug.Log("Failure message");
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Vertical");
        //Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);  
    }
}