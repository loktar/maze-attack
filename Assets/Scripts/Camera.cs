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
        Vector3 playerPosition = player.transform.position;
        float playerHeight = player.transform.localScale.y;
        float halfPlayerHeight = playerHeight / 2f;

        this.transform.position = playerPosition + new Vector3(0, halfPlayerHeight, 0);
    }
}
