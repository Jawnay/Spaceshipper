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
        // SpawnBlueEnemies(1);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            GameObject newEnemy = Instantiate(blueEnemy, spawnPoints[i]);
            // UnityEngine.AI.NavMeshAgent newAgent = newEnemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
            // newAgent.enabled = false;
        }
    }
}
