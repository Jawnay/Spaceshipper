using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public enum EnemyState
    {
        Wander, // Walk around randomly
        Chase,  // Chase player once spotted
        Evade   // Run away when health is low (may or may not implement, we'll see)
    }

    // Stats
    public int health = 3;

    // Behavior
    public EnemyState state;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;
    public float wanderRadius;
    public float wanderTimer;

    // Vision
    private int visionRange = 10;   // Max range for raycast

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Wander;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Wander)
        {
            timer += Time.deltaTime;
    
            if (timer >= wanderTimer) {
                Vector3 newPos = RandomWander(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
        else if (state == EnemyState.Chase)
        {

        }
    }

    // Physics (like raycast) must happen here
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.forward); // TODO: Vector3.forward is not relative to enemy's rotation. This will have to be found another way.
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, visionRange))
        {
            GameObject spotted = hit.transform.gameObject;

            // If hits player (PLAYER MJST HAVE 'Player' TAG!)
            if (spotted.tag == "Player")
            {
                // Set target to the player and begin chasing
                Debug.Log("Player spotted by enemy.");
                target = spotted.transform;
                state = EnemyState.Chase;
            }
        }
    }

    public static Vector3 RandomWander(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        UnityEngine.AI.NavMeshHit navHit;
 
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}
