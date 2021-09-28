using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public FloorSpawner floorSpawner;
    public static bool isFall;
    public float speedToAdd;


    // Start is called before the first frame update
    void Start()
    {
        isFall = false;
        direction = Vector3.forward;    
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0.5f)
        {
            isFall = true;
        }

        if (isFall)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
            speed += speedToAdd * Time.deltaTime;
            
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * Time.deltaTime * speed;
        transform.position += movement;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "floor"){
            other.gameObject.AddComponent<Rigidbody>();
            ScoreManager.score++;
            floorSpawner.SpawnFloor();
            StartCoroutine(DeleteFloor(other.gameObject));
        }
    }

    IEnumerator DeleteFloor(GameObject deletedfloor)
    {
        yield return new WaitForSeconds(3f);
        Destroy(deletedfloor);
    }

}
