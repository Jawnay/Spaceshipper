using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blueEnemy; // Blue enemy prefab

    // Start is called before the first frame update
    void Start()
    {
        SpawnBlueEnemies(1);
    }

    public void SpawnBlueEnemies(int howMany)
    {
        // Case for maxing out # of spawnPoints
        if (howMany > spawnPoints.Length)
        {
            howMany = spawnPoints.Length;
        }

        for (int i = 0; i < howMany; i++)
        {
            Debug.Log("Instantiate: Spawning enemy.");

            UnityEngine.AI.NavMeshHit spawn = GenerateSpawnFromPoint(spawnPoints[i]);

            GameObject newEnemy = Instantiate(blueEnemy, spawn.position, spawnPoints[i].rotation);
            // UnityEngine.AI.NavMeshAgent newAgent = newEnemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
            // newAgent.enabled = false;
        }
    }

    public UnityEngine.AI.NavMeshHit GenerateSpawnFromPoint(Transform point)
    {
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(point.position, out hit, 10.0f, UnityEngine.AI.NavMesh.AllAreas);
        return hit;
    }
}
