using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Blink()
    {
    	while (true)
    	{
	    	Color temp = gameObject.GetComponent<Image>().color;
			temp.a = 0f;
			gameObject.GetComponent<Image>().color = temp;
			yield return new WaitForSeconds(0.02f);
			temp.a = 255f;
			gameObject.GetComponent<Image>().color = temp;
			yield return new WaitForSeconds(0.02f);	
    	}
    	
    }
}
