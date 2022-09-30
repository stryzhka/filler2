using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCameraMoving : MonoBehaviour
{
    public float speed;
    public GameObject Player;
    public GameObject CutsceneCamera;
    public GameObject Canvas;
    public AudioSource CutsceneSound;
    public AudioSource Music, Conversation;
    public Transform Teleport;
    public GameObject Wall, Monsters;
    bool move = true;
    bool tp = false;
    public bool BossTriggered;
    bool successTrigger = false;
    void Start()
    {
    	StartCoroutine(Ready());
    }

    // Update is called once per frame
    void Update()
    {
        if (move)	
        	transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;
        if (!CutsceneSound.isPlaying && !tp)
        {
        	Player.transform.position = Teleport.transform.position;
        	tp = true;
        	StartCoroutine(PlayMusic());
        }
        if (BossTriggered && !successTrigger)
        {
        	StartCoroutine(Fight());
        	successTrigger = true;
        }
    }
    IEnumerator MoveCamera()
    {
    	yield return new WaitForSeconds (40f);
    	move = false;
    	CutsceneCamera.SetActive(false);
    	Player.SetActive(true);
    	Canvas.SetActive(true);
    }
    IEnumerator Ready()
    {
    	yield return new WaitForSeconds (0.0001f);
    	Player.SetActive(false);
    	Canvas.SetActive(false);
        StartCoroutine(MoveCamera());
    }
    IEnumerator PlayMusic()
    {
    	Music.Play();
    	yield return new WaitForSeconds(11f);
    	Monsters.SetActive(true);
    	Wall.SetActive(false);
    }

    IEnumerator Fight()
    {

    	Conversation.Play();
    	Player.GetComponent<WeaponController>().HasWeapon = false;
    	yield return new WaitForSeconds(1f);
    }
}
