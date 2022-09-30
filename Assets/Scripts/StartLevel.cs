using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public List<string> levelNames;
    public bool exit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartScene()
    {
    	
    	if (exit)
            Application.Quit();
    	SceneManager.LoadScene(levelNames[Random.Range(0, levelNames.Count)], LoadSceneMode.Single);
    	
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
            StartScene();
    }
}
