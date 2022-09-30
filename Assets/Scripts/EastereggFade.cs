using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EastereggFade : MonoBehaviour
{
    // Start is called before the first frame update
    public Image sprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color temp = sprite.color;
	 	temp.a += Time.deltaTime / 10f;
	    sprite.color = temp;
    }
}
