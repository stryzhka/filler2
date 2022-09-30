using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
    	if (col.gameObject.tag == "Player")
    	{
    		Interact();
    	}
    }

    public virtual void Interact()
    {
    	print ("Interacted");
    	Destroy(gameObject);
    }
}
