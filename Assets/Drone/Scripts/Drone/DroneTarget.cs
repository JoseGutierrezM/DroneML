using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTarget : MonoBehaviour
{
    DroneAgent droneAgent = null;

    [SerializeField] float goalReward = 0.1f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Drone")
        {
            droneAgent = collider.transform.parent.GetComponent<DroneAgent>();
            droneAgent.AddPositiveReward(droneAgent.drone.Information.currentSpeed * goalReward + 3);
            //droneAgent.AddPositiveReward(goalReward);
            //if (drone.Information.currentSpeed > drone.Information.landingVelocity && drone.Information.currentSpeed < 0)          
        }
    }
}