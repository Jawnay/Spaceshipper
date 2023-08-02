using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dash_display : MonoBehaviour
{
    public GameObject playerGameObject;
    // Start is called before the first frame update
    void Start()
    {
         playerGameObject = GameObject.FindGameObjectWithTag("Player");
        int charactercontrols = playerGameObject.GetComponent<CharacterControls>().maxSpeedBoostCount;
        Debug.Log("please update" + charactercontrols);
        if (charactercontrols == null)
        {
            Debug.LogError("characterControls script not assigned in the Inspector!");
            return;
        }
        GameObject dashesLGameObject = GameObject.Find("dashes_l");
        if (dashesLGameObject == null)
        {
            Debug.LogError("dashes_l GameObject not found!");
            return;
        }

        Text numberText = dashesLGameObject.GetComponent<Text>();
        if (numberText == null)
        {
            Debug.LogError("Text component not found on dashes_l GameObject!");
            return;
        }

        UpdateHUD(charactercontrols);
        
    }

    // Update is called once per frame
    void Update()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        int charactercontrols = playerGameObject.GetComponent<CharacterControls>().maxSpeedBoostCount;
        UpdateHUD(charactercontrols);
        
    }

    private void UpdateHUD(int value) 
    {
         Debug.Log("UpdateHUD called with value: " + value);
        GameObject dashesLGameObject = GameObject.Find("dashes_l");
        if (dashesLGameObject != null)
        {
            Text numberText = dashesLGameObject.GetComponent<Text>();
            if (numberText != null)
            {
                numberText.text = "Dashes Left: " + value.ToString();
            }
        }
    }
}
