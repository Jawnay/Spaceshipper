using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private LayerMask mineableObject;
    [SerializeField] private ObjectsHealth objectsHealth;
<<<<<<< Updated upstream
=======
    private Transform playerTransform;
    private itemAppear itemAppear; // Reference to the ItemAppear script
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
{
    GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player");
    if (playerCharacter != null)
    {
<<<<<<< Updated upstream
        
=======
        playerTransform = playerCharacter.transform;
        itemAppear = playerCharacter.GetComponent<itemAppear>();
>>>>>>> Stashed changes
    }
    else
    {
        Debug.LogError("Player not found! Make sure to tag your player character with 'Player'.");
    }
}


    // Update is called once per frame
    void Update()
{
    if (playerTransform == null || itemAppear == null)
    {
<<<<<<< Updated upstream
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
=======
        return;
    }

    if (Input.GetMouseButtonDown(0))
    {
        if (itemAppear.pickaxe) // Check if the pickaxe is equipped
        {
            // Calculate the mining direction based on the player's facing direction
            Vector3 miningDirection = playerTransform.forward;

            // Create a ray starting from the player's position in the mining direction
            Ray ray = new Ray(playerTransform.position, miningDirection);

>>>>>>> Stashed changes
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, range, mineableObject)){
                objectsHealth = hit.transform.GetComponent<ObjectsHealth>(); 
                objectsHealth.objectsHealth -= damage;
            }
        }
        else
        {
            // Player does not have the pickaxe equipped, so they can't mine.
            Debug.Log("You need a pickaxe to mine!");
        }
    }
}
}


