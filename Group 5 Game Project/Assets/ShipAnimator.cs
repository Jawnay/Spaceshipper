using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimator : MonoBehaviour
{
    public Animator ship;
    public bool isShipDown;
    public bool matCollected;
    public bool returnShip;
    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Animator>();
        isShipDown = false;
        matCollected = false;
        ship.SetBool("returnShip", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShipDown)
        {
            ship.Play("ship_anim", 0, 0.0f);
            isShipDown = true;
        }

        if(matCollected && isShipDown)
        {
            ship.SetBool("returnShip", true);
            ship.Play("ship_anim", 0, -1.0f);
            isShipDown = false;
        }
    }
}
