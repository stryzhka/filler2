using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouth : MonoBehaviour
{
    public GameObject Player;
    public WeaponController w;
    public GameObject Screamer, Monster;
   	public Transform Spawner;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
    	while (true)
    	{
    		GameObject m = Instantiate (Monster, Spawner.position, Quaternion.identity);
	    	yield return new WaitForSeconds(2f);
	    	GameObject s = Instantiate (Screamer, Spawner.position, Quaternion.identity);
	    	yield return new WaitForSeconds(2f);
    	}
    	
    }
}
