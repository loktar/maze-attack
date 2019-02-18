using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public float movementSpeed = 1;
    public float rotationSpeed = 1;
    public int startingWaypointIndex = 0;
    public DemonWaypoints demonWaypoints;
    public GameObject deathPanel;

    private Waypoint targetWaypoint;
    private WaypointFinder waypointFinder;

    // Start is called before the first frame update
    void Start()
    {
        waypointFinder = GetComponent<WaypointFinder>();

        MoveInstantlyToWaypoint(demonWaypoints.waypoints[startingWaypointIndex]);
        TargetRandomVisibleWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = targetWaypoint.transform.position;

        MoveTowardPosition(targetPosition);
        FaceTowardPosition(targetPosition);

        if (transform.position == targetPosition)
        {
            TargetRandomVisibleWaypoint();
        }
    }

    private void MoveInstantlyToWaypoint(GameObject waypoint)
    {
        this.transform.position = waypoint.transform.position;
    }

    private void TargetRandomVisibleWaypoint()
    {
        targetWaypoint = FindRandomVisibleWaypoint() ?? targetWaypoint;
    }

    private Waypoint FindRandomVisibleWaypoint()
    {
        Waypoint[] visibleWaypoints = waypointFinder.FindVisibleWaypoints();
        Waypoint[] potentialTargets = Array.FindAll(visibleWaypoints, w => w.transform.position != this.transform.position);

        if (potentialTargets.Length > 0)
        {
            int randomIndex = new System.Random().Next(0, potentialTargets.Length);
            return potentialTargets[randomIndex];
        }

        return null;
    }

    private void FaceTowardPosition(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void MoveTowardPosition(Vector3 targetPosition)
    {
        float step = movementSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You hit the demon!");
        deathPanel.SetActive(true);
    }
}
