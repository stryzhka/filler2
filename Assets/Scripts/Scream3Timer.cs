using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scream3Timer : MonoBehaviour
{
    public int Timer;
    public Text TimerText;
    public Score ScoreObject;
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = Timer.ToString();
        if (Timer <= 0)
        {
        	ScoreObject.IsCompleted = true;
        }
    }

    IEnumerator Wait()
    {
    	do
    	{
    		Timer--;
    		yield return new WaitForSeconds(1f);
    	} while (Timer > 0);
    	
    }
}
