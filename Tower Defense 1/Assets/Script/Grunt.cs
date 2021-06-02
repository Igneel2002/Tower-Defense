using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Grunt : MonoBehaviour
{
    [SerializeField]
    public Text LifeCounter;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Waypoint[] waypoints;
    public float LIFE = 100;
    [SerializeField]
    [HideInInspector]
    public GameObject SP1;
    [SerializeField]
    public GameObject[] EnemyPOS;

    [HideInInspector] public Waypoint SeventhPoint => waypoints[Random.Range(0, waypoints.Length)];

    // Start is called before the first frame update
    void Start()
    {
    
        agent = gameObject.GetComponent<NavMeshAgent>();
        // FindOfObjectsOfType gets every instance of this component in the scene
        waypoints = FindObjectsOfType<Waypoint>();

        // Tell the agent to move to a random position in the scene waypoints
        agent.SetDestination(SeventhPoint.Position);

    }

    // Update is called once per frame
    void Update()
    {
        LifeCounter.text = LIFE.ToString();

        // Has the agent reached it's position?
        if (!agent.pathPending && agent.remainingDistance == 0)
        {
            StartCoroutine(Delay(2f));
        }
    }

    private IEnumerator Delay(float _Delay)
    {
        EnemyPOS[0].SetActive(false);

        LIFE -= 2;

        yield return new WaitForSeconds(_Delay);

        transform.position = SP1.transform.position;

        EnemyPOS[0].SetActive(true);

        agent.SetDestination(SeventhPoint.Position);
    }
}
