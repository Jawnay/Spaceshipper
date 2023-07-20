using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyState
    {
        Wander, // Walk around randomly
        Chase,  // Chase player once spotted
        Evade   // Run away when health is low (may or may not implement, we'll see)
    }

    // Movement
    public EnemyState state;
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;
    public float wanderRadius;
    public float wanderTimer;

    // Attacking
    public float meleeRange = 5.0f;

    // Animation
    public float speed = 0;
    Vector3 lastPosition = Vector3.zero;
    public Animator anim;

    // Vision
    private int visionRange = 10;   // Max range for raycast

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Wander;
        target = null;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Wander)
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Wander();
            }
        }
        else if (state == EnemyState.Chase)
        {
            Chase();
        }
    }

    // Physics (like raycast) must happen here
    void FixedUpdate()
    {
        // Raycast
        Vector3 relativeForward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, relativeForward);
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

        // Speed check
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        
        if (speed > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (TargetInMeleeRange())
        {
            // TODO: Attack. In separate class?
            anim.SetBool("inMeleeRange", true);
        }
        else
        {    
            anim.SetBool("inMeleeRange", false);
        }
    }

    void Wander()
    {
        // Debug.Log("Moving to new destination.");
        Vector3 newPos = RandomWander(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);
        timer = 0;
    }

    void Chase()
    {
        if (TargetTooFar(5.0f))
        {
            // Player ran away far enough, go back to wandering
            state = EnemyState.Wander;
        }
        else
        {
            // Chase player
            agent.SetDestination(target.position);
        }
    }

    // Determines a random point on the NavMesh to travel to.
    public static Vector3 RandomWander(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        UnityEngine.AI.NavMeshHit navHit;
 
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }

    // Returns true if player gets 'dist' units away in X and Z directions
    bool TargetTooFar(float dist)
    {
        if (target.position.x - transform.position.x > dist && target.position.z - transform.position.z > dist)
        {
            return true;
        }
        return false;
    }

    // Returns true if the target is being chased and is within melee range.
    bool TargetInMeleeRange()
    {
        if (target.position.x - transform.position.x < meleeRange && target.position.z - transform.position.z < meleeRange)
        {
            return true;
        }
        return false;
    }
}
