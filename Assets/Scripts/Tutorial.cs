using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Text Text1;
    public Text Text2;
    public CreatureBehaviour CreatureTrigger;
    public GameObject Weapon;
    public GameObject Crosshair;
    public GameObject Enemies;
    public Transform Player;
    bool first, second, final;
    void Start()
    {
        final = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CreatureTrigger.Dead)
        {
        	StartCoroutine(DeadReact());
        }
        if (Player.position.y <= -500 && final)
        {
        	SceneManager.LoadScene("Preview", LoadSceneMode.Single);
        }
        if (Player.position.y <= -500 && !final)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnCollisionEnter(Collision col)
    {
    	if (!first && col.gameObject.tag == "TrollTrigger")
    	{
    		print ("smth");
    		Text2.gameObject.SetActive(true);
    		first = true;
    	}

    	
    }

    void OnTriggerEnter(Collider col)
    {
    	if (!second && col.gameObject.tag == "Trigger")
    	{
    		print ("smth2");
    		Text1.text = "ЛАДНО, ТЫ ПОНЯЛ КАК ПРЫГАТЬ НА МОНСТРЕ. ХАХАХА ЭТО НЕ СПАСЕТ ТЕБЯ ОТ СМЕРТИ";
    		Text2.text = "ТЫ ПОТЕРЯЕШЬ МНОГО ЗДОРОВЬЯ";
    		StartCoroutine(Hide());
    		second = true;
    	}
    }

    IEnumerator Hide()
    {
    	yield return new WaitForSeconds(3f);
    	Text1.text = "ВОЗЬМИ ОРУЖИЕ";
    	Text2.text = "С ПОМОЩЬЮ НЕГО ТВОЙ КОНЕЦ НАСТУПИТ ПОЗЖЕ";
    	Weapon.SetActive(true);
    	Crosshair.SetActive(true);
    	yield return new WaitForSeconds(3f);
    	Text1.gameObject.SetActive(false);
    	Text2.gameObject.SetActive(false);


    }

    IEnumerator DeadReact()
    {
    	Text1.gameObject.SetActive(true);
    	Text2.gameObject.SetActive(true);
    	Text1.text = "ПОСМОТРИМ КАК ОНИ ОТРЕАГИРУЮТ НА СМЕРТЬ ИХ ДРУГА";
    	Text2.text = "ОНИ ОТОМСТЯТ";
    	yield return new WaitForSeconds(3f);
    	Text1.gameObject.SetActive(false);
    	Text2.gameObject.SetActive(false);
    	Enemies.SetActive(true);
    	final = true;
    }
}
