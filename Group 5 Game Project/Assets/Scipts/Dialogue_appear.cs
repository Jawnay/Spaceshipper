using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appear : MonoBehaviour
{
    public GameObject dialogueBox;
    public float proximity = 5f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueBox = GameObject.FindGameObjectWithTag("dialogue");

        dialogueBox.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= proximity)
        {
            dialogueBox.SetActive(true);
        } 
        else 
        {
            dialogueBox.SetActive(false);
        }
    }
}
