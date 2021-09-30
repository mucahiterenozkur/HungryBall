using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    Vector3 direction = Vector3.forward;
    public float speed;
    public FloorSpawner floorSpawner;
    public static bool isFall;
    public float speedToAdd;
    public TextMeshProUGUI gameOverText;
    public GameObject playAgainButton;
    public GameObject mainMenuButton;
    public GameObject quitButton;

    public Animator animator;

    private ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        isFall = false;
        direction = Vector3.forward;
        scoreManager = FindObjectOfType<ScoreManager>();
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
            animator.SetBool("isGameOver", true);
            scoreManager.scoreText.enabled = false;
            gameOverText.text = "Game Over!" + Environment.NewLine + "Your Score: " + ScoreManager.score;
            gameOverText.enabled = true;
            playAgainButton.SetActive(true);
            mainMenuButton.SetActive(true);
            quitButton.SetActive(true);
            return;
        }
        else
        {
            animator.SetBool("isGameOver", false);
            scoreManager.scoreText.enabled = true;
            gameOverText.enabled = false;
            playAgainButton.SetActive(false);
            mainMenuButton.SetActive(false);
            quitButton.SetActive(false);
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && (direction != Vector3.right))
        {
            direction = Vector3.left;
            speed += speedToAdd * Time.deltaTime;

        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && (direction != Vector3.left))
        {
            direction = Vector3.right;
            speed += speedToAdd * Time.deltaTime;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (direction != Vector3.back))
        {
            direction = Vector3.forward;
            speed += speedToAdd * Time.deltaTime;
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && (direction != Vector3.forward))
        {
            direction = Vector3.back;
            speed += speedToAdd * Time.deltaTime;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (direction.x == 0)
        //    {
        //        direction = Vector3.left;
        //    }
        //    else
        //    {
        //        direction = Vector3.forward;
        //    }
        //    speed += speedToAdd * Time.deltaTime;

        //}
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
