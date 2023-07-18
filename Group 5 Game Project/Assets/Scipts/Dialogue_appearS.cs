using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_appearS : MonoBehaviour
{
    public GameObject dialogueBox1;
    public float proximity = 5f;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueBox1 = GameObject.FindGameObjectWithTag("dialogue1");

        dialogueBox1.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= proximity)
        {
            dialogueBox1.SetActive(true);
        } 
        else 
        {
            dialogueBox1.SetActive(false);
        }
    }
}
