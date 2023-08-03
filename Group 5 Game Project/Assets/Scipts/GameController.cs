using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public RockSpawner[] rockSpawners;
    public GameObject continueLevel;
    //public TimerCountdown timerCountdown;

    // Start is called before the first frame update
    void Start()
    {
        continueLevel = GameObject.FindGameObjectWithTag("Continue");
        continueLevel.SetActive(false);
        
        // Initialize rock spawners
        rockSpawners[0].Init(0, 0, 0, 0, 0, 0);


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

        gameObject.GetComponent<TimerCountdown>().secondsLeft = 140;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

        // Load canvas for starting level2...

        // Wipe rocks and spawn new rocks
        foreach (RockSpawner rs in rockSpawners)
        {
            rs.WipeRocks();
        }

    }

    void LoadLevel2()
    {
        // 1r, 1o, 1y, 1b, 1g | 2be, 1re
        gameObject.GetComponent<TimerCountdown>().secondsLeft = 160;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

        ResetPlayerHealth();

        // Load canvas for starting level3...

        // logic for making the continue panel show up once done
        
    }

    void LoadLevel3()
    {
        // 1r, 2o, 1y, 1b, 2g | 2be, 2re
        gameObject.GetComponent<TimerCountdown>().secondsLeft = 180;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        ResetPlayerHealth();

        // Load canvas for starting level4...
        
    }

    void LoadLevel4()
    {
        // 2r, 2o, 1y, 2b, 1g | 2be, 2re
        gameObject.GetComponent<TimerCountdown>().secondsLeft = 200;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        ResetPlayerHealth();

        
    }

    void ResetPlayerHealth()
    {
        gameObject.GetComponent<PlayerHealth>().health = 90;

    }

    void OnContinueButton()
    {
        continueLevel.SetActive(false);
    }
}
