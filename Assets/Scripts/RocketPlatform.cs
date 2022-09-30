using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlatform : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
    	print ("aaa");
    	if (col.gameObject.name == "Player")
    	{
    		col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100000f, ForceMode.VelocityChange);
    	}
    }
}
