using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform ball;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BallMovement.isFall)
        {
            transform.position = ball.position + distance;
        }
        
    }
}
