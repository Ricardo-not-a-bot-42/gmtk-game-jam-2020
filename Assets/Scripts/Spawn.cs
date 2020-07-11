using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] Projecteis;
    private float spawnTime;
    public float firstSpawnTime;
    public float minSpawnTime;
    public float Diminuir;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (spawnTime <= 0)
            {

                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = Projecteis[Random.Range(0, Projecteis.Length)];
                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);
                if (firstSpawnTime > minSpawnTime)
                {
                    firstSpawnTime -= Diminuir;
                }

                spawnTime = firstSpawnTime;

            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
    }
}
