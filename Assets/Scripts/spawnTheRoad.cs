using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTheRoad : MonoBehaviour
{
    public GameObject[] obestaclesPrefabs;
    private List<GameObject> activePrefabs;
    public float zSpawn = 0;
    public float obstacleLength = 12;
    public int numberOfObestacles = 6;
    public Transform playerPostion;
    void Start()
    {
        activePrefabs = new List<GameObject>();
        for (int i = 0; i < numberOfObestacles; i++)
        {
            if (i == 0)
                spawnRoad(0);
            else
                spawnRoad(Random.Range(1, obestaclesPrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPostion.position.z -120 >  zSpawn - (numberOfObestacles * 120))
        {
            Destroy(activePrefabs[0]);
            activePrefabs.RemoveAt(0);
            spawnRoad(Random.Range(1, obestaclesPrefabs.Length));
        }
    }
    private void spawnRoad(int obstacleIndex)
    {
        GameObject tile = Instantiate(obestaclesPrefabs[obstacleIndex], transform.forward * zSpawn, transform.rotation);
        activePrefabs.Add(tile);
        zSpawn += obstacleLength;
    }
    
}
