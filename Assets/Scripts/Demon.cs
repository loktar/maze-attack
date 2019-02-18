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

    private int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = demonWaypoints.waypoints[startingWaypointIndex].transform.position;
        this.targetIndex = startingWaypointIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = demonWaypoints.waypoints[targetIndex].transform.position;

        MoveTowardPosition(targetPosition);
        FaceTowardPosition(targetPosition);

        if (transform.position == targetPosition)
        {
            FindNextTargetWaypoint(targetPosition);
        }
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

    private void FindNextTargetWaypoint(Vector3 targetPosition)
    {
        targetIndex++;
        if (targetIndex >= demonWaypoints.waypoints.Length)
        {
            targetIndex = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You hit the demon!");
        deathPanel.SetActive(true);
    }
}
