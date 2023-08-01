using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUpgradeScript : MonoBehaviour
{
    [SerializeField] private bool inTrigger;
    [SerializeField] private int playerCoins;
    public int upgradeCoinCost;
    public GameObject Player;
    public Player CharacterControls;
    public GameObject PlayerResources;
    public PlayerResources playerResourcesScript;

    public void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
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
    }

    // Update is called once per frame
    void Update()
    {
        playerResourcesScript = PlayerResources.GetComponent<PlayerResources>();
        playerCoins = playerResourcesScript.value;
        if(inTrigger){
            if(Input.GetKeyDown(KeyCode.Z))
            {
                upgradeDash();
            }
        }
    }

    private void upgradeDash() 
    {
        // need to take off coins when upgrading
        if(playerCoins >= upgradeCoinCost)
        {
            CharacterControls = Newplayertest.GetComponent<CharacterControls>();
            if(CharacterControls.maxSpeedBoostCount <= 9)
            {
                CharacterControls.maxSpeedBoostCount = maxSpeedBoostCount + 1; 
                upgradeCoinCost = upgradeCoinCost * 2;
            } else {
                Debug.Log("You have reached the maximum upgrade level for num dashes");
            }
        }
    }
}
