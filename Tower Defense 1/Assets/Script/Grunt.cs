using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Grunt : Enemies
{
    public Grunt grunt;
    MENU menu;
    Enemies enemy;
    [SerializeField]
    public GameObject[] EnemyPOS;




    // Start is called before the first frame update
    void Awake()
    {

        
            agent = gameObject.GetComponent<NavMeshAgent>();
            // FindOfObjectsOfType gets every instance of this component in the scene
            waypoints = FindObjectsOfType<Waypoint>();

            // Tell the agent to move to a random position in the scene waypoints
            agent.SetDestination(SeventhPoint.Position);
        

    }

    private void Update()
    {
        // And if the remain distance between waypoint and grunt is less than 0.25
        if (agent.remainingDistance < 0.25)
        {
            // play Coroutine
            StartCoroutine(Delay(30f));
        }
    }

    public IEnumerator Delay(float _Delay)
    {
        // take damage from total health in game
        GruntSpawn.LIFE -= 5;
        // destroy enemy
        Destroy(gameObject);
        // Make coroutine work
        yield return (_Delay);
    }
}

