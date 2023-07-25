using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeepBehavior : MonoBehaviour
{
    public GameObject dialogTrigger;
    ShopkeeperDialog triggerInfo;

    public GameObject dialogCanvas;

    // Start is called before the first frame update
    void Start()
    {
        triggerInfo = dialogTrigger.GetComponent<ShopkeeperDialog>();
    }

    void Update()
    {
        if (triggerInfo.targetSpotted)
        {
            Transform t = triggerInfo.target.transform;
            Vector3 newtarget = t.position;
            newtarget.y = transform.position.y;
            transform.LookAt(newtarget);
        }        
    }
}
