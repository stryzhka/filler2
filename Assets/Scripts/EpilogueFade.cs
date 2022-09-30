using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpilogueFade : MonoBehaviour
{
    // Start is called before the first frame update
    public Image sprite;
    public bool first, second;
    public Color temp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (first)
    	{

    		temp = sprite.color;
	 		temp.a -= Time.deltaTime / 10f;
	    	sprite.color = temp;
    	}

        
    }
}
