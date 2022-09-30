using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStandartPlayerprefs : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetFloat("ShootingSpeedBonus", 0.1f);
        PlayerPrefs.SetFloat("HealthBonus", 0);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("Score", 0);
    }

    
    void Update()
    {
        
    }
}
