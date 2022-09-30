using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDoor : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider col)
    {
    	print ("aasda");
    	if (col.gameObject.name == "Player")
    	{
    		Destroy(gameObject);
    	}
    }
}
