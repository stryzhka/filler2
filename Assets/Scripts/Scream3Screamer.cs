using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scream3Screamer : MonoBehaviour
{
    public float MyTime;
    public bool ScreamEnabled;
    public int PlayerSpots;
    public float StartHealth, Health, WasHealth;
    public AudioClip Clip;
    public AudioSource Source;
    
    void Start()
    {
    	GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(Appear(MyTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSpots >= 2)
        {
			SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
			print ("scream");
        }

        if (Health <= 0)
        {
        	WasHealth = StartHealth;
        	Health = StartHealth;
        	GetComponent<MeshRenderer>().enabled = false;
    		ScreamEnabled = false;
    		PlayerSpots = 0;
    		print ("ouch");
        }
    }

    public void GetDamage(float dmg)
    {
    	WasHealth = Health;
    	Health -= dmg;
    }

    IEnumerator Appear(float t)
    {
    	while (true)
    	{
    		yield return new WaitForSeconds(t + Random.Range(0,4));
    		GetComponent<MeshRenderer>().enabled = true;
    		ScreamEnabled = true;
    		Source.PlayOneShot(Clip);
    		yield return new WaitForSeconds(t + Random.Range(0,4));
    		GetComponent<MeshRenderer>().enabled = false;
    		ScreamEnabled = false;
    		if (WasHealth == Health)
    		{
    			PlayerSpots++;
    		}
    	}
    }
}
