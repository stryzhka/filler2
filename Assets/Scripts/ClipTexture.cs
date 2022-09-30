using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipTexture : MonoBehaviour
{
    public List<Texture2D> Textures = new List<Texture2D>();
    public float speed;

    void Start()
    {
        StartCoroutine(Change());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Change()
    {
    	int i = 0;
    	while (true)
    	{
    		yield return new WaitForSeconds(speed);
    		gameObject.GetComponent<MeshRenderer>().material.mainTexture = Textures[i];
    		i++;
    		if (i >= Textures.Count)
    		{
    			i = 0;
    		}
    	}
    	
    }
}
