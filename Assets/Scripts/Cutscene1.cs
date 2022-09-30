using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1 : MonoBehaviour
{
    public GameObject Cube1, Cube2, Cube3;
    public AudioSource Audio1, Audio2, Audio3, Audio4;
    void Start()
    {
        StartCoroutine(Cutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cutscene()
    {
    	Audio1.Play();
    	yield return new WaitForSeconds(4f);
    	Cube1.SetActive(false);
    	Cube2.SetActive(true);
    	Audio2.Play();
    	yield return new WaitForSeconds(2f);
    	Cube2.SetActive(false);
    	Audio3.Play();
    	Cube3.SetActive(true);
    	yield return new WaitForSeconds(2f);
    	Audio4.Play();
    	Cube3.GetComponent<Rigidbody>().useGravity = true;
    	Cube3.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.VelocityChange);
    }
}
