using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFinder : MonoBehaviour
{
    private Waypoint[] allWaypoints;

    // Start is called before the first frame update
    void Start()
    {
        allWaypoints = FindObjectsOfType<Waypoint>();
        Debug.Log("Found " + allWaypoints.Length + " waypoints in the scene");
    }

    // Update is called once per frame
    void Update()
    {
        //FindVisibleWaypoints();
    }

    public Waypoint[] FindVisibleWaypoints()
    {
        Waypoint[] visibleWaypoints = Array.FindAll(allWaypoints, CanSeeWaypoint);
        Debug.Log("I can see " + visibleWaypoints.Length + " waypoints");
        return visibleWaypoints;
    }

    private bool CanSeeWaypoint(Waypoint waypoint)
    {
        Vector3 direction = waypoint.transform.position - this.transform.position;
        Physics.Raycast(this.transform.position, direction, out RaycastHit hitInfo);
        return hitInfo.collider && hitInfo.collider.GetComponent<Waypoint>() == waypoint;
    }
}
