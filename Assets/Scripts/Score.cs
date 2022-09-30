using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int CurrentScore;
    public int ReachScore;
    public int KeysObtained;
    public int ButtonsPressed;
    public Text ScoreText;
    public bool Scream3;
    public bool Scream5;
    public bool IsCompleted;
    public WeaponController Player;
    public GameObject Mouth;
    public GameObject EyesHp;
    public int Eyes;
    bool final = false;
    public AudioSource Final;
    public AudioSource Music;
    public GameObject ImageFade;
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    	CheckScore();
        Draw();
        CheckCompleted();
    }

    public void AddScore(int tmp)
    {
    	CurrentScore += tmp;
    }

    void CheckScore()
    {
    	if (CurrentScore >= ReachScore)
    	{
    		IsCompleted = true;
    	}
    	if (KeysObtained == 2)
    	{
    		IsCompleted = true;
    	}
        if (ButtonsPressed == 2)
        {
            Player.HasWeapon = true;
            Mouth.SetActive(true);
            EyesHp.SetActive(true);
        }
        if (Eyes == 2 && !final)
        {
            final = true;
            Mouth.SetActive(false);
            Music.Stop();
            StartCoroutine(PredFinal());
        }
    }

    void CheckCompleted()
    {
    	if (IsCompleted)
    	{
    		Time.timeScale = 0.1f;
    		if (Input.GetKeyDown("space"))
    		{
    			Time.timeScale = 1f;
    			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
    			SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    		}
    	}
    }

    void Draw()
    {
    	if (!Scream3 && !Scream5)
    	{
    		if (!IsCompleted)
    		ScoreText.text = CurrentScore.ToString();
    		else
    		ScoreText.text = CurrentScore.ToString() + " PRESS SPACE";	
    	}
    	else if (!Scream5)
    	{
    		if (!IsCompleted)
    			ScoreText.text = "KEYS OBTAINED: " + KeysObtained.ToString();	
    		else
    			ScoreText.text = "KEYS OBTAINED: " + KeysObtained.ToString() + " PRESS SPACE";	
    	}
    	else
    	{
    		ScoreText.text = "ESCAPE FROM SCREAM";	
    	}
    }

    IEnumerator FinalDelay()
    {
        ImageFade.SetActive(true);
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("Epilogue", LoadSceneMode.Single);
    }

    IEnumerator PredFinal()
    {
        yield return new WaitForSeconds(9f);
        Final.Play();
        yield return new WaitForSeconds(5f);
        StartCoroutine(FinalDelay());
    }
}
