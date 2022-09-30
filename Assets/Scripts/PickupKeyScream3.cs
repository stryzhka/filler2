using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKeyScream3 : Pickup
{
    public Score ScoreObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        print ("Get key");
    	ScoreObject.KeysObtained++;
        Destroy(gameObject);
    }
}
