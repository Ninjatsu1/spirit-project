using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Move : MonoBehaviour
{
    public Transform[] waypoints;
    public int destinationPoint = 0;
    private NavMeshAgent agent; //Character
    public bool isMoving = true;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && isMoving == true)
        {
            GoToNextPoint();
        }
        if (isMoving == false)
        {
            agent.isStopped = true;
        }
    }
    public virtual void GoToNextPoint() //Patrol movement
    {
        //return nothing if points has not been set
        if (waypoints.Length == 0)
        {
            // Debug.Log("No waypoints");
            return;
        }
        // Set the agent to go to the currently selected destination.
        agent.destination = waypoints[destinationPoint].position;
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destinationPoint = (destinationPoint + 1) % waypoints.Length;
    }
}

