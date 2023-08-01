using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public void ActivateHitbox()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateHitbox()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player hit the enemy.");
            other.gameObject.GetComponentInChildren<EnemyMovement>().TakeDamage();
        }
        if (other.CompareTag("RedEnemy"))
        {
            Debug.Log("Player hit the enemy.");
            other.gameObject.GetComponentInChildren<RedEnemyMovement>().TakeDamage();
        }
    }
}
