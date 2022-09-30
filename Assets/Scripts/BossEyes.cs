using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEyes : MonoBehaviour
{
    public Transform Player;
    public float Health;
    public Slider Healthbar;
    public AudioSource Death;
    public bool dead = false;
    public Score s;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        Healthbar.value = Health;
        CheckHp();
    }

    public void GetDamage(float dmg)
    {
    	Health -= dmg;
    }

    void CheckHp()
    {
    	if (Health <= 0)
    	{
    		if (!dead)
    		{
    			dead = true;
    			Destroy(gameObject);
    			Death.Play();
	    		s.Eyes++;
	    		
	    			
	    		
    		}
    		
    	}
    }
}
