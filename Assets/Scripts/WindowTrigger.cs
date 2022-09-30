using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public AudioSource BreakSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
    	if (col.gameObject.tag == "CutsceneTable")
    	{
    		print ("check");
    		BreakSound.Play();
    		gameObject.GetComponent<Rigidbody>().isKinematic = false;
    		gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(10000f, 0f, 0f));
    	}
    }
}
