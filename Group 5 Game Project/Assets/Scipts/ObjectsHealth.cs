using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHealth : MonoBehaviour
{
    public int objectsHealth;
    [SerializeField] private PlayerResources playerResources;
    public string oreType { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        playerResources = GameObject.Find("Player Resources").GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectsHealth <= 0)
        {
            // Update the corresponding ore type value based on the tag
            switch (oreType)
            {
                case "RedOre":
                    playerResources.RedOreValue += Random.Range(1, 5);
                    break;
                case "BlueOre":
                    playerResources.BlueOreValue += Random.Range(1, 5);
                    break;
                case "GreenOre":
                    playerResources.GreenOreValue += Random.Range(1, 5);
                    break;
                case "YellowOre":
                    playerResources.YellowOreValue += Random.Range(1, 5);
                    break;
                case "OrangeOre":
                    playerResources.OrangeOreValue += Random.Range(1, 5);
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
