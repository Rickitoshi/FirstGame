using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject[] RoadPrefabs;

    private void Start()
    {
        SpawnRoad(0, -95);
        SpawnRoad(0, -295);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if(other.tag == "FinishFloor")
        {
            SpawnRoad(0, -295);
        }
    }
    private void SpawnRoad(int index, float position)
    {
        Instantiate(RoadPrefabs[index], new Vector3(position, 0, 0), transform.rotation);
    }
}
