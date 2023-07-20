using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hit with attack.");
            other.attachedRigidbody.gameObject.GetComponent<player_health>().health -= 15;
        }
    }
}
