using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text Money, Health, Gun, CompletedText;
    public GameObject ShopCanvas, BossEntrounce;
    public int money, score;
    public float health, gun;
    void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        score = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        CompletedText.text = "COMPLETED: " + score;
        Money.text = "MONEY: " + money;
        Health.text = "HEALTH BONUSES: " + health + "PRESS Q TO BUY";
        Gun.text = "GUN BONUSES:" + gun + "PRESS E TO BUY";
        if (Input.GetKeyDown("escape"))
        {
        	ShopCanvas.SetActive(false);
        	PlayerPrefs.SetFloat("ShootingSpeedBonus", PlayerPrefs.GetFloat("ShootingSpeedBonus") + gun);
        	PlayerPrefs.SetFloat("HealthBonus", PlayerPrefs.GetFloat("HealthBonus") + health);
        	PlayerPrefs.SetInt("Money", money);
        }

        if (Input.GetKeyDown("q"))
        {
        	if (money >= 2)
        	{
        		health += 5f;
        		money -= 2;
        	}
        }
        if (Input.GetKeyDown("e"))
        {
        	if (money >= 1)
        	{
        		if (gun <= 0.2)
        		{
	        		gun += 0.01f;
	        		money -= 1;
        		}
        		
        	}
        }
        if (score >= 20)
        {
            BossEntrounce.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider col)
    {
    	if (col.gameObject.name == "Player")
    	{
    		ShopCanvas.SetActive(true);
    	}
    }
}
