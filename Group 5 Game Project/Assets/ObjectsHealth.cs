using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHealth : MonoBehaviour
{
    public int objectsHealth;
    [SerializeField] private PlayerResources playerResources;
    // Start is called before the first frame update
    void Start()
    {
        playerResources = GameObject.Find("Player Resources").GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectsHealth <= 0){
            playerResources.value += Random.Range(1,5);
            Destroy(gameObject);
        }
    }
}
