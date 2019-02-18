using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        LookUpOrDown();
    }

    private void FollowPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        float playerHeight = player.transform.localScale.y;
        float halfPlayerHeight = playerHeight / 2f;

        this.transform.position = playerPosition + new Vector3(0, halfPlayerHeight, 0);
        this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void LookUpOrDown()
    {
        float rotateVertical = Input.GetAxis("Tilt Head");
        Vector3 rotationDelta = new Vector3(rotateVertical * player.rotationSpeed * Time.deltaTime, 0, 0);

        this.transform.eulerAngles += rotationDelta;
    }
}
