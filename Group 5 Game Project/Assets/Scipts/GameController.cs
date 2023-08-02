using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public RockSpawner rockSpawner;

    // Start is called before the first frame update
    void Start()
    {
        // Load level 1
        LoadLevel1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel1()
    {
        // 1r, 0o, 0y, 1b, 1g | 2be, 1re

        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

        // Load canvas for starting level2...

    }

    void LoadLevel2()
    {
        // 1r, 1o, 1y, 1b, 1g | 2be, 1re
        
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

        resetPlayerHealth();

        // Load canvas for starting level3...
        
    }

    void LoadLevel3()
    {
        // 1r, 2o, 1y, 1b, 2g | 2be, 2re

        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        resetPlayerHealth();

        // Load canvas for starting level4...
        
    }

    void LoadLevel4()
    {
        // 2r, 2o, 1y, 2b, 1g | 2be, 2re

        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        resetPlayerHealth();

        
    }

    void resetPlayerHealth()
    {
        gameObject.GetComponent<PlayerHealth>().health = 90;

    }

    void wipeRocks()
    {

    }
}
