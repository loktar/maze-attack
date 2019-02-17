using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public float movementSpeed;
    public int startingWaypointIndex = 0;
    public GameObject[] pathWaypoints;
    public GameObject deathPanel;

    private int targetIndex;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = pathWaypoints[startingWaypointIndex].transform.position;
        this.targetIndex = startingWaypointIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = pathWaypoints[targetIndex].transform.position;

        MoveTowardPosition(targetPosition);

        if (transform.position == targetPosition)
        {
            FindNextTargetWaypoint(targetPosition);
        }
    }

    private void MoveTowardPosition(Vector3 targetPosition)
    {
        float step = movementSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    private void FindNextTargetWaypoint(Vector3 targetPosition)
    {
        targetIndex++;
        if (targetIndex >= pathWaypoints.Length)
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
