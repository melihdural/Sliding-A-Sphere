using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PointSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject point;

    private int spawnCount = 0;
    
    private float posX;
    private float posZ;
    

    private void Update()
    { 
        RandomPoint();
        Vector3 spawnPoint = new Vector3(posX, 0, posZ);

        while (spawnCount<10)
        {
            Instantiate(point, spawnPoint, Quaternion.identity);
        }

        spawnCount++;


    }

    private void RandomPoint()
    {
        float randomX = Random.Range(-5f, 5f);
        posX = randomX;

        float randomZ = Random.Range(-5f, 5f);
        posZ = randomZ;
        
    }
}
