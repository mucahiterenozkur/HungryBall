using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject lastFloor;

    private void Awake()
    {
        for(int i = 0; i < 15; i++)
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
        Vector3 direction;
        if (Random.Range(0, 2) == 0)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.forward;
        }

        lastFloor = Instantiate(lastFloor,lastFloor.transform.position + direction, lastFloor.transform.rotation);
    }
}
