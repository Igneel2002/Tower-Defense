using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableArea : MonoBehaviour
{
    public Color highlightColour;
    public Vector3 posOffset;
    public GameObject turret;


    private Renderer rend;
    private Color startColour;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }
    void Update()
    {
        Vector3 mouseLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);   // Get The Mouse Position on both the X and Y axix
        if (Input.GetMouseButtonDown(0))   // If mouse button 1 is push (Left Click)
        {
            Vector3 worldpos;
            Ray ray = Camera.main.ScreenPointToRay(mouseLocation);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                worldpos = hit.point;    // finds a hit and sets it to the world pos variable
            }
            else
            {
                worldpos = Camera.main.ScreenToWorldPoint(mouseLocation);
            }
            if (gameObject.tag == "Buildable") // if the area tag is marked with buildable 
            {
                Instantiate(turret, worldpos, Quaternion.identity);   // Instantiate the turret at the worldpos
            }
            
        }
        
    }
    private void OnMouseDown()
    {
        //if (turret != null)
        //{
        //    Debug.Log("Can't Build there");
        //    return;
        //}
        //GameObject generateTurret = BuildManager.bmInstance.GenerateTurret();
        //turret = (GameObject)Instantiate(generateTurret, transform.position + posOffset, transform.rotation);
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
