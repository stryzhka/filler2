using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public CutsceneCameraMoving temp;
    public GameObject Eyes;
    bool getData = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
    	if (col.gameObject.name == "Player" && !getData)
    	{
    		temp.BossTriggered = true;
    		getData = true;
    		Eyes.SetActive(true);

    	}
    }
}
