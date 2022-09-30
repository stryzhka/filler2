using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream5Trigger : MonoBehaviour
{
    public bool Spotted;
    private bool Already;
    public AudioSource Audio;
    public GameObject Monsters, Door;
    public Light Light;
    public bool Key1, Key2;
    void Start()
    {
        Already = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Key1 && Key2)
        {
        	Door.SetActive(false);
        	print ("DSFGDG");
        }
    }

    public IEnumerator Spot()
    {
    	if (!Already)
    	{
    		Already = true;
    		Light.color = Color.red;
    		Light.gameObject.GetComponent<LightFlash>().enabled = true;
    		Audio.Play();
	    	yield return new WaitForSeconds(6f);
	    	Monsters.SetActive(true);

    	}
    	
    }
}
