using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// upgrade key is U

public class AxeUpgrade : MonoBehaviour
{
    [SerializeField] private bool inTrigger;
    [SerializeField] private int playerCoins;
    [SerializeField] private int minObjectHealth;
    public int upgradeCoinCost;
    public GameObject MiningManager;
    public MiningManager miningManagerScript;
    public GameObject PlayerResources;
    public PlayerResources playerResourcesScript;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("In Trigger");
            inTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
        upgradeCoinCost = 10;
        minObjectHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        playerResourcesScript = PlayerResources.GetComponent<PlayerResources>();
        playerCoins = playerResourcesScript.value;
        if(inTrigger){
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Z Pressed");
                upgradePickAxe();
            }
        }
    }

    private void upgradePickAxe() 
    {
        if(playerCoins >= upgradeCoinCost)
        {
            miningManagerScript = MiningManager.GetComponent<MiningManager>();
            if(miningManagerScript.damage <= minObjectHealth)
            {
                miningManagerScript.damage = miningManagerScript.damage + 20;
            } else {
                Debug.Log("You have reached the maximum upgrade level for this pickaxe");
            }
        } else {
            Debug.Log("Not enough coins.");
        }
    }
}