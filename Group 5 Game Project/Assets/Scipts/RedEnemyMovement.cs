using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyMovement : MonoBehaviour
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
    public Rigidbody rb;
    private float timer;
    public float wanderRadius;
    public float wanderTimer;

    // Attacking
    public float meleeRange;
    public GameObject attack; // Object with trigger hitbox

    // Animation
    public float speed = 0;
    Vector3 lastPosition = Vector3.zero;
    public Animator anim;

    // Vision
    private int visionRange = 20;   // Max range for raycast

    // Stats
    public RedEnemyStats stats;
    public bool invincible;

    // Babies
    public GameObject blueEnemy;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Wander;
        target = null;
        stats = GetComponent<RedEnemyStats>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = 0;

        invincible = false;
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

        // if (Physics.Raycast(ray, out hit, visionRange))
        if (Physics.SphereCast(transform.position, 2.5f, relativeForward, out hit, visionRange))
        {
            GameObject spotted = hit.transform.gameObject;

            // If hits player (PLAYER MJST HAVE 'Player' TAG!)
            if (spotted.tag == "Player")
            {
                // Set target to the player and begin chasing
                // Debug.Log("Player spotted by enemy.");
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
        if (target != null)
        {
            if (target.position.x - transform.position.x < meleeRange && target.position.z - transform.position.z < meleeRange)
            {
                return true;
            }
        }
        return false;
    }

    public void TakeDamage()
    {
        if (!invincible)
        {
            invincible = true;

            // Update health
            stats.health--;

            // KnockBack();

            // Play animation
            anim.SetBool("tookDamage", true);
            Invoke("EndDamage", 1.5f);

            if (stats.health == 0)
            {
                anim.SetBool("isDead", true);
                Invoke("Die", 1.5f);
            }
        }
    }

    // void KnockBack()
    // {
    //     rb.AddForce(transform.forward * -1, ForceMode.Impulse);
    //     rb.AddForce(transform.up, ForceMode.Impulse);
    // }

    void EndDamage()
    {
        anim.SetBool("tookDamage", false);
        invincible = false;
    }

    void Die()
    {
        // Determine spawn points for babies
        Vector3 babySpawn1 = RandomWander(transform.position, wanderRadius, -1);
        Vector3 babySpawn2 = RandomWander(transform.position, wanderRadius, -1);

        // Spawn babies
        Instantiate(blueEnemy, babySpawn1, transform.rotation);
        Instantiate(blueEnemy, babySpawn2, transform.rotation);

        // Destory parent
        Destroy(gameObject);
    }
}