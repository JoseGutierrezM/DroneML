using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTarget : MonoBehaviour
{
    DroneAgent agent = null;

    [SerializeField] float goalReward = 0.1f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Drone")
        {
            agent = collider.transform.parent.GetComponent<DroneAgent>();
            agent.AddPositiveReward(goalReward);
        }
    }
}