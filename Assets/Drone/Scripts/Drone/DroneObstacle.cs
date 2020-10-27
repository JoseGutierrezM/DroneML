using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneObstacle : MonoBehaviour
{
    DroneAgent droneAgent = null;

    [SerializeField] float goalReward = -0.1f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Drone")
        {
            droneAgent = collider.transform.parent.GetComponent<DroneAgent>();
            droneAgent.AddPositiveReward(droneAgent.drone.Information.currentSpeed * goalReward - 1);          
        }
    }
}
