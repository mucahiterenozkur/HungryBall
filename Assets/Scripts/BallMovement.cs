using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BallMovement : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public FloorSpawner floorSpawner;
    public static bool isFall;
    public float speedToAdd;
    public TextMeshProUGUI gameOverText;


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
            gameOverText.text = "Game Over!" + Environment.NewLine + "Your Score: " + ScoreManager.score;
            gameOverText.enabled = true;
            return;
        }
        else
        {
            gameOverText.enabled = false;
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "food")
        {
            Debug.Log("food");
            Destroy(other.gameObject);
            ScoreManager.score += 3;
        }
    }

    IEnumerator DeleteFloor(GameObject deletedfloor)
    {
        yield return new WaitForSeconds(3f);
        Destroy(deletedfloor);
    }

}
