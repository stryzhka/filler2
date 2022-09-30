using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    public AudioSource Sound;
    private bool isPlayed = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
    	if (!isPlayed)
    	if (col.tag == "CutsceneTable")
    	{
    		print("check");
    		Sound.Play();
    		isPlayed = true;
    	}
    	 
    }
}
