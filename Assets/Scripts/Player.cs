using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10;
    public float rotationSpeed = 10;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        float moveForward = Input.GetAxis("Vertical");
        float moveSideways = Input.GetAxis("Horizontal");

        this.transform.position += this.transform.forward * moveForward * movementSpeed * Time.deltaTime;
        this.transform.position += this.transform.right * moveSideways * movementSpeed * Time.deltaTime;
    }

    private void RotatePlayer()
    {
        float rotateHorizontal = Input.GetAxis("Rotate Player");

        this.transform.eulerAngles += new Vector3(0, rotateHorizontal, 0) * rotationSpeed * Time.deltaTime;
    }
}
