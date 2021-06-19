using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public GameObject Grunt2;
    public GameObject Tank2;
    public GameObject Ninja2;

    [HideInInspector]
    public NavMeshAgent agent;


    [HideInInspector]
    public Waypoint[] waypoints;
    [HideInInspector] public Waypoint SeventhPoint => waypoints[Random.Range(0, waypoints.Length)];
}
