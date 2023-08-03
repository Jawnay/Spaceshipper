using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public RockSpawner[] rockSpawners;
    public int[] numRocksToSpawn;       // Determines how many rocks are spawned at any given location.
    public int numRocksIndex;           // For iterating through numRocksToSpawn
    public bool isNext;
    //public TimerCountdown timerCountdown;

    // Start is called before the first frame update
    void Start()
    {
        isNext = gameObject.GetComponent<ShipTriggerScript>().nextLevel;
        // Initialize rock spawners
        rockSpawners = new RockSpawner[14];
        numRocksToSpawn = new int[] { 2, 2, 2, 2, 2, 2, 2, 3, 3, 2, 2, 5, 1 };
        rockSpawners[0].Init(195f, 213f, 69f, 70f, 63f, 100f);
        rockSpawners[1].Init(360f, 405f, 53f, 54f, 233f, 244f);
        rockSpawners[2].Init(65f, 75f, 27f, 27.5f, 393f, 400f);
        rockSpawners[3].Init(400f, 415f, 60f, 60.8f, 75f, 95f);
        rockSpawners[4].Init(310f, 317f, 51f, 51.38f, 300f, 314f);
        rockSpawners[5].Init(69f, 77f, 51.5f, 52f, 60f, 70f);
        rockSpawners[6].Init(171f, 180f, 64.5f, 65f, 81f, 92f);
        rockSpawners[7].Init(400f, 410f, 60f, 61f, 70f, 93f);
        rockSpawners[8].Init(350f, 375f, 19.7f, 20f, 372f, 390f);
        rockSpawners[9].Init(230f, 235f, 52f, 52f, 425f, 430f);
        rockSpawners[10].Init(174f, 182f, 51f, 51.25f,383f, 390f);
        rockSpawners[11].Init(70f, 71f, 25f, 25.5f, 395f, 425f);
        rockSpawners[12].Init(135f, 150f, 64.7f, 65.2f, 111f, 125f);
        rockSpawners[13].Init(100f, 144f, 76.8f,77.8f, 180f, 205f);
        


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
        ResetLevel();

        gameObject.GetComponent<TimerCountdown>().secondsLeft = 140;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

        // Wipe rocks and spawn new rocks
        if (isNext) {
            LoadLevel2();
        }

    }

    void LoadLevel2()
    {
        // 1r, 1o, 1y, 1b, 1g | 2be, 1re
        ResetLevel();
        
        gameObject.GetComponent<TimerCountdown>().secondsLeft = 160;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

        // Wipe rocks and spawn new rocks
        if (isNext) {
            LoadLevel3();
        }
    }

    void LoadLevel3()
    {
        // 1r, 2o, 1y, 1b, 2g | 2be, 2re
        ResetLevel();
        
        gameObject.GetComponent<TimerCountdown>().secondsLeft = 180;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        // Wipe rocks and spawn new rocks
        if (isNext) {
            LoadLevel4();
        }
        
    }

    void LoadLevel4()
    {
        ResetLevel();
        // 2r, 2o, 1y, 2b, 1g | 2be, 2re
        gameObject.GetComponent<TimerCountdown>().secondsLeft = 200;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        // Wipe rocks and spawn new rocks
        if (isNext) {
            // Load a you win canvas
            SceneManager.LoadScene(6);
        }
        
    }

    void ResetPlayerHealth()
    {
        gameObject.GetComponent<PlayerHealth>().health = 90;

    }

    void ResetLevel()
    {
        // Wipe rocks and spawn new rocks
        numRocksIndex = 0;
        foreach (RockSpawner rs in rockSpawners)
        {
            rs.WipeRocks();
            rs.SpawnRocks(numRocksToSpawn[numRocksIndex]);
            numRocksIndex++;
        }

        ResetPlayerHealth();   
    }
}