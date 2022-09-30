using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCamera : MonoBehaviour
{
    public float f;
    public GameObject Image;
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        print ("rotatigg");
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.Euler(0f, -290f, 0f), f * Time.deltaTime);
    }

    IEnumerator Wait()
    {
    	yield return new WaitForSeconds(1.5f);
    	Image.SetActive(true);
    	yield return new WaitForSeconds(8f);
    	SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
