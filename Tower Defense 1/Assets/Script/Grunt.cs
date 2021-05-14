using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Grunt : MonoBehaviour
{
    private NavMeshAgent agent;
    private Waypoint[] waypoints;
    private Waypoint1[] waypoints1;
    [SerializeField]
    public static float goal = 0f;

    private Waypoint FirstPoint => waypoints[Random.Range(0, waypoints.Length)];
    private Waypoint1 SecondPoint => waypoints1[Random.Range(0, waypoints1.Length)];

    // Start is called before the first frame update
    void Start()
    {
    
        agent = gameObject.GetComponent<NavMeshAgent>();
        // FindOfObjectsOfType gets every instance of this component in the scene
        waypoints = FindObjectsOfType<Waypoint>();
        waypoints1 = FindObjectsOfType<Waypoint1>();

        // Tell the agent to move to a random position in the scene waypoints
        agent.SetDestination(FirstPoint.Position);
    }

    // Update is called once per frame
    void Update()
    {
        // Has the agent reached it's position?
        if (!agent.pathPending && agent.remainingDistance == 0)
        {
            if (goal == 1)
            {
            // Tell the agent to move to a random position in the scene waypoints
            agent.SetDestination(SecondPoint.Position);
            }
        }
    }
}
