using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]
public class Grunt : MonoBehaviour
{
    [SerializeField]
    public Text LifeCounter;
    private NavMeshAgent agent;
    private Waypoint[] waypoints;
    private Waypoint1[] waypoints1;
    private Waypoint2[] waypoints2;
    private Waypoint3[] waypoints3;
    private Waypoint4[] waypoints4;
    private Waypoint5[] waypoints5;
    private Waypoint6[] waypoints6;
    private float goal = 0f;
    public float LIFE = 100;

    private Waypoint FirstPoint => waypoints[Random.Range(0, waypoints.Length)];
    private Waypoint1 SecondPoint => waypoints1[Random.Range(0, waypoints1.Length)];
    private Waypoint2 ThirdPoint => waypoints2[Random.Range(0, waypoints1.Length)];
    private Waypoint3 FourthPoint => waypoints3[Random.Range(0, waypoints1.Length)];
    private Waypoint4 FifthPoint => waypoints4[Random.Range(0, waypoints1.Length)];
    private Waypoint5 SixthPoint => waypoints5[Random.Range(0, waypoints1.Length)];
    private Waypoint6 SeventhPoint => waypoints6[Random.Range(0, waypoints1.Length)];

    // Start is called before the first frame update
    void Start()
    {
    
        agent = gameObject.GetComponent<NavMeshAgent>();
        // FindOfObjectsOfType gets every instance of this component in the scene
        waypoints = FindObjectsOfType<Waypoint>();
        waypoints1 = FindObjectsOfType<Waypoint1>();
        waypoints2 = FindObjectsOfType<Waypoint2>();
        waypoints3 = FindObjectsOfType<Waypoint3>();
        waypoints4 = FindObjectsOfType<Waypoint4>();
        waypoints5 = FindObjectsOfType<Waypoint5>();
        waypoints6 = FindObjectsOfType<Waypoint6>();

        // Tell the agent to move to a random position in the scene waypoints
        agent.SetDestination(FirstPoint.Position);

    }

    // Update is called once per frame
    void Update()
    {
        LifeCounter.text = LIFE.ToString();

        // Has the agent reached it's position?
        if (!agent.pathPending && agent.remainingDistance == 0)
        {
            goal += 1;
            if (goal == 1)
            {
            // Tell the agent to move to a random position in the scene waypoints
            agent.SetDestination(SecondPoint.Position);
            }
            
            if (goal == 2)
            {
            // Tell the agent to move to a random position in the scene waypoints
            agent.SetDestination(ThirdPoint.Position);
            }

            if (goal == 3)
            {
                // Tell the agent to move to a random position in the scene waypoints
                agent.SetDestination(FourthPoint.Position);
            }

            if (goal == 4)
            {
                // Tell the agent to move to a random position in the scene waypoints
                agent.SetDestination(FifthPoint.Position);
            }

            if (goal == 5)
            {
                // Tell the agent to move to a random position in the scene waypoints
                agent.SetDestination(SixthPoint.Position);
            }

            if (goal == 6)
            {
                // Tell the agent to move to a random position in the scene waypoints
                agent.SetDestination(SeventhPoint.Position);

                LIFE -= 2;
            }
        }
    }
}
