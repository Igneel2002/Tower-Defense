using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableArea : MonoBehaviour
{
    public Color highlightColour;
    public Vector3 posOffset;
    private GameObject turret;


    private Renderer rend;
    private Color startColour;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't Build there");
            return;
        }
        GameObject generateTurret = BuildManager.bmInstance.GenerateTurret();
        turret = (GameObject)Instantiate(generateTurret, transform.position + posOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        rend.material.color = highlightColour;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColour;
    }
}
