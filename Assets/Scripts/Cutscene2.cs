using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{
    public AudioSource Bored;
    public AudioClip BoredScary;
    public AudioClip Confusion;
    private bool CanActivateTrigger;
    public bool StartAlpha;
    public Image sprite;
    public GameObject flash;
    public Camera c1, c2;
    void Start()
    {
        StartCoroutine(BeginCutscene());
    }

    // Update is called once per frame
    void Update()
    {
    	if (StartAlpha)
    	{
    		Color temp = sprite.color;
	 		temp.a += Time.deltaTime / 3f;
	    	sprite.color = temp;
	    	print ("changing");

	    	
    	}
        
    }

    IEnumerator BeginCutscene()
    {
    	yield return new WaitForSeconds(1f);
    	Bored.Play();
    	yield return new WaitForSeconds(5f);
    	CanActivateTrigger = true;
    }

    IEnumerator Scream()
    {
    	yield return new WaitForSeconds(6f);
    	Bored.PlayOneShot(BoredScary);
    	yield return new WaitForSeconds(3f);
    	Bored.PlayOneShot(Confusion);
    	yield return new WaitForSeconds(5f);
    	SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    void OnTriggerEnter(Collider col)
    {
    	if (CanActivateTrigger)
    	{
    		if (col.gameObject.name == "Player")
    		{
    			StartAlpha = true;
    			c1.gameObject.SetActive(false);
    			c2.gameObject.SetActive(true);
    			StartCoroutine(Scream());
    		}
    	}
    }
}
