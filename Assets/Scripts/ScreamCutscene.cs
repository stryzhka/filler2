using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamCutscene : MonoBehaviour
{
    public float Wait;
    public GameObject SpawnMonster, SpawnMonster2, Audio, Audio1;
    public GameObject Dis1, Dis2, Dis3;
    public AudioSource Sound;
    void Start()
    {
        StartCoroutine(Waiting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Waiting()
    {
    	yield return new WaitForSeconds(20f);
    	Sound.Play();
    	yield return new WaitForSeconds(5f);
    	GameObject temp = Instantiate(SpawnMonster, transform.position, Quaternion.identity);
    	GameObject temp2 = Instantiate(SpawnMonster2, transform.position, Quaternion.identity);
    	Audio.SetActive(true);
    	Dis1.SetActive(false);
    	Dis2.SetActive(false);
    	Dis3.SetActive(false);
    	Audio1.SetActive(true);
    }
}
