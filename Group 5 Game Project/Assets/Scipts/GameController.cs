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
    public int isNext;
    public GameObject ship;
    public GameObject Player;
    public RoundManager roundManager;
    public TimerCountdown timerCountdown;
    public int currentLevel;
    public int completedLevel;

    // Start is called before the first frame update
    void Start()
    {
        completedLevel = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        ship = GameObject.FindGameObjectWithTag("Ship");
        isNext = ship.GetComponent<ShipTriggerScript2>().nextLevel;
        // Initialize rock spawners
        numRocksToSpawn = new int[] {2, 2, 1, 1, 1, 1, 1, 3, 3, 1, 1, 5, 1, 3};
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
        ship = GameObject.FindGameObjectWithTag("Ship");
       isNext = ship.GetComponent<ShipTriggerScript2>().nextLevel;
       Debug.Log("here");
        Debug.Log("What is isNext" + isNext);
        if (isNext != completedLevel) {
            Debug.Log("here1");
            //currentLevel = 1;
            completedLevel++;
            if (isNext == 1 && completedLevel == 1) {
                //completedLevel = 1;
                Debug.Log("This thing happens");
                LoadLevel2();

            } else if (isNext == 2 && completedLevel == 2) {
                LoadLevel3();
            } else if (isNext == 3 && completedLevel == 3) {
                LoadLevel4();
            }
        }
        
    }

    void LoadLevel1()
    {
        // 1r, 0o, 0y, 1b, 1g | 2be, 1re
        ResetLevel();

        // Prompt
        roundManager.SetRequiredOres(1, 0, 0, 1, 1);

        timerCountdown.secondsLeft = 140;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

    }

    void LoadLevel2()
    {
        // 1r, 1o, 1y, 1b, 1g | 2be, 1re
        //isNext = false;
        ResetLevel();
        // Prompt
        roundManager.SetRequiredOres(1, 1, 1, 1, 1);

        timerCountdown.secondsLeft = 160;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(1);

        // Wipe rocks and spawn new rocks
    }

    void LoadLevel3()
    {
        //isNext = false;
        // 1r, 2o, 1y, 1b, 2g | 2be, 2re
        ResetLevel();
        
        // Prompt
        roundManager.SetRequiredOres(1, 2, 1, 1, 2);


        timerCountdown.secondsLeft = 180;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        // Wipe rocks and spawn new rocks
        
    }

    void LoadLevel4()
    {
        ResetLevel();
        // 2r, 2o, 1y, 2b, 1g | 2be, 2re

        // Prompt

        roundManager.SetRequiredOres(2, 2, 1, 2, 1);


        timerCountdown.secondsLeft = 200;
        // Spawn enemies
        enemySpawner.SpawnBlueEnemies(2);
        enemySpawner.SpawnRedEnemies(2);

        // Wipe rocks and spawn new rocks
        if (isNext == 4) {
            // Load a you win canvas
            SceneManager.LoadScene(6);
        }
        
    }

    void ResetPlayerHealth()
    {
        Player.GetComponent<PlayerHealth>().health = 90;
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