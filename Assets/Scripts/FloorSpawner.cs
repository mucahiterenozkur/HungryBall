using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject lastFloor;
    public List<GameObject> collectibles = new List<GameObject>();
    private Vector3 upVector = new Vector3(0, 0.6f, 0);
    GameObject food;
    Vector3 direction = Vector3.forward;

    private void Awake()
    {
        for(int i = 0; i < 100; i++)
        {
            SpawnFloor();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFloor()
    {
        Vector3 direction = Vector3.forward;
        if (Random.Range(0, 4) == 0 && direction != Vector3.right)
        {
            direction = Vector3.left;
            if(Random.Range(0,2) == 0)
            {
                int foodtoSpawn = Random.Range(0, collectibles.Count);
                food = Instantiate(collectibles[foodtoSpawn], lastFloor.transform.position + upVector, lastFloor.transform.rotation);
            }
        }
        else if(Random.Range(0, 4) == 1 && direction != Vector3.left)
        {
            direction = Vector3.right;
            if (Random.Range(0, 2) == 0)
            {
                int foodtoSpawn = Random.Range(0, collectibles.Count);
                food = Instantiate(collectibles[foodtoSpawn], lastFloor.transform.position + upVector, lastFloor.transform.rotation);
            }
        }
        else if (Random.Range(0, 4) == 2 && direction != Vector3.forward)
        {
            direction = Vector3.back;
            if (Random.Range(0, 2) == 0)
            {
                int foodtoSpawn = Random.Range(0, collectibles.Count);
                food = Instantiate(collectibles[foodtoSpawn], lastFloor.transform.position + upVector, lastFloor.transform.rotation);
            }
        }
        else if(Random.Range(0, 4) == 3 && direction != Vector3.back)
        {
            direction = Vector3.forward;
            if (Random.Range(0, 2) == 0)
            {
                int foodtoSpawn = Random.Range(0, collectibles.Count);
                food = Instantiate(collectibles[foodtoSpawn], lastFloor.transform.position + upVector, lastFloor.transform.rotation);

            }
        }

        lastFloor = Instantiate(lastFloor,lastFloor.transform.position + direction, lastFloor.transform.rotation);
    }


}
