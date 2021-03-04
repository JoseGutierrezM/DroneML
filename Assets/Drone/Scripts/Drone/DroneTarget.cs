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
            Debug.Log(collider.transform.parent.parent.name);
            droneAgent = collider.transform.parent.GetComponent<DroneAgent>();
            droneAgent.AddPositiveReward(droneAgent.drone.Information.currentSpeed * -goalReward + 4);
        }
    }
}