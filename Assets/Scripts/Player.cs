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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(moveHorizontal, 0, moveVertical) * movementSpeed;
    }

    private void RotatePlayer()
    {
        float rotateHorizontal = Input.GetAxis("Rotate Player");
        Debug.Log("Rotate horizontal: " + rotateHorizontal);

        this.transform.eulerAngles += new Vector3(0, rotateHorizontal, 0) * rotationSpeed;
    }
}
