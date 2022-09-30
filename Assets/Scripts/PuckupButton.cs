using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupButton : Pickup
{
    public Score s;
    public bool Pressed = false;
    public GameObject ButtonLight;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public override void Interact()
    {
    	if (!Pressed)
    	{
    		s.ButtonsPressed++;
    		Pressed = true;
    		Destroy(ButtonLight);
    		print ("pressed button");
    	}
    }
}
