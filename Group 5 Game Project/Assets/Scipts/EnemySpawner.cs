using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blueEnemy; // Blue enemy prefab
    public GameObject redEnemy;  // Red enemy prefab

    int nextSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnPoint = 0;
        //SpawnBlueEnemies(1);
        //SpawnRedEnemies(2);
    }

    public void SpawnBlueEnemies(int howMany)
    {
        // Case for maxing out # of spawnPoints
        if (howMany > spawnPoints.Length - 1)
        {
            howMany = spawnPoints.Length - 1;
        }

        for (int i = 0; i < howMany; i++)
        {
            Debug.Log(nextSpawnPoint);
            UnityEngine.AI.NavMeshHit spawn = GenerateSpawnFromPoint(spawnPoints[nextSpawnPoint]);
            GameObject newEnemy = Instantiate(blueEnemy, spawn.position, spawnPoints[nextSpawnPoint].rotation);
            nextSpawnPoint++;
            if(nextSpawnPoint == spawnPoints.Length){
                nextSpawnPoint = 0;
            }
        }
    }

    public void SpawnRedEnemies(int howMany)
    {
        // Case for maxing out # of spawnPoints
        if (howMany > spawnPoints.Length)
        {
            howMany = spawnPoints.Length;
        }

        for (int i = 0; i < howMany; i++)
        {
            UnityEngine.AI.NavMeshHit spawn = GenerateSpawnFromPoint(spawnPoints[nextSpawnPoint]);
            GameObject newEnemy = Instantiate(redEnemy, spawn.position, spawnPoints[nextSpawnPoint].rotation);
            nextSpawnPoint++;
        }
    }

    public UnityEngine.AI.NavMeshHit GenerateSpawnFromPoint(Transform point)
    {
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(point.position, out hit, 10.0f, UnityEngine.AI.NavMesh.AllAreas);
        return hit;
    }
}
