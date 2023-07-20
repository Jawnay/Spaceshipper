using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningManager : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private LayerMask mineableObject;
    [SerializeField] private ObjectsHealth objectsHealth;
    private Transform playerTransform;

    void Start()
    {
        // Find the player character using the "Player" tag
        GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player");

        // Check if the player character was found
        if (playerCharacter != null)
        {
            playerTransform = playerCharacter.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure to tag your player character with 'Player'.");
        }
    }

    void Update()
    {
        // If playerTransform is still not assigned, exit the Update function
        if (playerTransform == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Calculate the mining direction based on the player's facing direction
            Vector3 miningDirection = playerTransform.forward;

            // Create a ray starting from the player's position in the mining direction
            Ray ray = new Ray(playerTransform.position, miningDirection);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, mineableObject))
            {
                objectsHealth = hit.transform.GetComponent<ObjectsHealth>();
                objectsHealth.objectsHealth -= damage;
            }
        }
    }
}
