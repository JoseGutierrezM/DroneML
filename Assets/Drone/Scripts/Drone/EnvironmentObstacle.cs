using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObstacle : MonoBehaviour
{
    DroneAgent droneAgent = null;

    [SerializeField] float goalReward = -0.1f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Drone")
        {
            droneAgent = collider.transform.parent.GetComponent<DroneAgent>();
            //droneAgent.AddPositiveReward(droneAgent.drone.Information.currentSpeed * goalReward - 1);
            //droneAgent.AddNegativeReward(droneAgent.drone.Information.currentSpeed * -1 + goalReward * 5);
            droneAgent.AddNegativeReward(goalReward * 2);
        }
    }
}