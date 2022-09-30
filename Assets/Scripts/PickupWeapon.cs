using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Pickup
{
    public WeaponController Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
    	Player.HasWeapon = true;
        print ("now has");
    	Destroy(gameObject);
    }
}
