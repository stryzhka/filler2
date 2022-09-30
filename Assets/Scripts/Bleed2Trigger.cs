using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed2Trigger : MonoBehaviour
{
    public GameObject Audio, Gordons, Floor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
    	if (col.gameObject.name == "Player")
    	{
    		Audio.SetActive(true);
    		StartCoroutine(StartAnother());
    	}
    }

    IEnumerator StartAnother()
    {
    	yield return new WaitForSeconds(7f);
    	Gordons.SetActive(true);
    	Floor.SetActive(false);
    }
}
