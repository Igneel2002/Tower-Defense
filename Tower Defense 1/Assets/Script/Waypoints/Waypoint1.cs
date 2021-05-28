using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint1 : MonoBehaviour
{
    public Vector3 Position => transform.position;

    // Simply a way to find any object marked as a waypoint

    // Implement this ONDrawGizmos if you want to draw gizmos that are also pickable and always drawn
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}
