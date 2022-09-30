using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed3CutsceneTrigger : MonoBehaviour
{
    public float WaitTime;
    public GameObject Monsters;
    public AudioSource Audio, Audio2;
    public GameObject g1, g2, g3, g4;
    private bool enabled;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitAndScream(float w)
    {
    	if (!enabled)
    	{
    		enabled = true;
    		
    	}
    	yield return new WaitForSeconds(w);
    	Audio.Play();
    	g1.SetActive(true);
    	yield return new WaitForSeconds(4f);
    	g1.SetActive(false);
    	g2.SetActive(true);
    	yield return new WaitForSeconds(5f);
    	g2.SetActive(false);
    	g3.SetActive(true);
    	yield return new WaitForSeconds(6f);
    	g3.SetActive(false);
    	g4.SetActive(true);
    	yield return new WaitForSeconds(4f);
    	g4.SetActive(false);
    	Audio2.Play();
    	yield return new WaitForSeconds(3f);
    	Monsters.SetActive(true);
    	

    }

    void OnTriggerEnter(Collider col)
    {
    	if (col.gameObject.name == "Player")
    	{
    		if (!enabled)
    		{
    			StartCoroutine (WaitAndScream(WaitTime));
    		}
    	}
    }
}
