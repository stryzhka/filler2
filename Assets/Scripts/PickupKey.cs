using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : Pickup
{
    public Scream5Trigger Trigger;
    public bool Key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        print ("FJKIAOSFJILOKF");
    	if (!Key)
            Trigger.Key1 = true;
        else
            Trigger.Key2 = true;
        Destroy(gameObject);
    }
}
