using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueCutscene : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Player;
    public AudioSource Audio1, Titles;
    public EpilogueFade e;
    public Transform Teleport;
    public GameObject Credits;
    bool rotating1 = true;
    bool rotating2 = true;
    void Start()
    {
        StartCoroutine(First());
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotating1)
        {
        	Camera1.transform.rotation = Quaternion.RotateTowards(Camera1.transform.rotation, Quaternion.Euler(-50f, -90f, 0f), 20 * Time.deltaTime);
        }
        if (!rotating2)
        {
        	//Camera1.transform.rotation = Quaternion.RotateTowards(Camera1.transform.rotation, Quaternion.Euler(0f, -18f, 0f), 20 * Time.deltaTime);
        	Camera1.transform.rotation = Quaternion.Lerp(Camera1.transform.rotation, Quaternion.Euler(0f, -18f, 0f), Time.deltaTime * 25f);
        }
    }

    IEnumerator First()
    {
    	yield return new WaitForSeconds(10f); //10
    	rotating1 = false;
    	yield return new WaitForSeconds(10f); //10
    	rotating1 = true;
    	Audio1.Play();
    	yield return new WaitForSeconds(27f); //27
    	rotating2 = false;
    	yield return new WaitForSeconds(1f);  //1
    	rotating2 = true;
    	Player.SetActive(true);
    	Camera1.SetActive(false);
    	yield return new WaitForSeconds(10f); //10
    	e.first = false;
    	e.temp.a = 255f;
    	e.sprite.color = e.temp;
    	yield return new WaitForSeconds(5f);
    	Player.transform.position = Teleport.position;
		e.temp.a = 0f;
    	e.sprite.color = e.temp;
    	Titles.Play();
    	yield return new WaitForSeconds(43f);
    	Credits.SetActive(true);
    	yield return new WaitForSeconds(78f);
    	Application.Quit();
    }
}
