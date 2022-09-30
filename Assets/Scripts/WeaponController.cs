using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeaponController : MonoBehaviour
{
	public Camera MyCamera;
	public bool FallingDisabled;
	public bool FirstCutscene;
	public bool Epilogue;
    public bool HasWeapon;
    public enum WeaponType {Bullet, Projectile, Light, Auto};
    public WeaponType MyWeaponType;
    public float Health;
    public bool Godmode;
    public GameObject ProjectilePrefab;
    public Transform ProjectileSpawner;
    public float ProjectileForce;
    public AudioSource Sound;
    public float WeaponDamage;
    public GameObject Light;
    public float ShootDelay;
    public float ShootingSpeedBonus;
    float nextFire;
    Slider Healthbar;

    void Start()
    {
        ShootingSpeedBonus = PlayerPrefs.GetFloat("ShootingSpeedBonus");
        ShootDelay = 0.2f - ShootingSpeedBonus;
        Health = 50f + PlayerPrefs.GetFloat("HealthBonus");
        Healthbar = GameObject.Find("Healthbar").GetComponent<Slider>();
    }

    void Shoot()
    {
    				Sound.Play();
		        	GameObject hit = GetTarget();
		        	Debug.Log(hit.GetComponent<Collider>().gameObject.name);
		        	if (hit.GetComponent<Collider>().gameObject.tag == "Creature")
		        	{
		        		hit.GetComponent<CreatureBehaviour>().GetDamage(WeaponDamage);
		        		hit.gameObject.GetComponent<CreatureBehaviour>().Spotted = true;
		        	}
		        	if (hit.GetComponent<Collider>().gameObject.tag == "Boss")
		        	{
		        		hit.GetComponent<BossEyes>().GetDamage(WeaponDamage);
		        		
		        	}

		        	
    }

    public GameObject GetTarget()
    {
	    GameObject result = null;
	    RaycastHit[] hits = Physics.RaycastAll(MyCamera.transform.position, MyCamera.transform.forward, 600);
	    float minRange = float.MaxValue;
	    foreach(RaycastHit ht in hits){
	        if(ht.distance<minRange && ht.collider.gameObject.tag != "Player"){
	          result = ht.collider.gameObject;
	          minRange = ht.distance;
	        }
	    }
    	return result;
	}

    void CheckY()
    {
    	if (transform.position.y <= -40)
    	{
    		if (FirstCutscene)
    		{
    			SceneManager.LoadScene("Easteregg", LoadSceneMode.Single);
    		}
    		else if (Epilogue)
    		{
    			print ("cant die here");
    		}
    		else
    		SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
    	}
    }

    public void GetDamage(float dmg)
    {
    	Health -= dmg;
    }
    public void GetHeal(float heal)
    {
    	Health += heal;
    }

    void CheckHealth()
    {
    	Healthbar.value = Health;
    	if (Health <= 0)
    	{
    		SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    	}
    }

    void Update()
    {
    	if (!FallingDisabled)
    		CheckY();
    	if (!Godmode)
    		CheckHealth();
    	if (Input.GetKeyDown("r"))
    	{
    		Time.timeScale = 1f;
    		Application.LoadLevel(Application.loadedLevel);
    	}
    	/*if (Input.GetKeyDown("escape"))
    	{
    		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    	}*/
    	
    	if (HasWeapon)
    	{
    		print ("have weapon");
    		if (Input.GetMouseButtonDown(0))
	        {
	        	if (MyWeaponType == WeaponType.Bullet)
	        	{
	        		print ("shoot");
	        		if (Time.time >= nextFire)
	        		{
	        			nextFire = Time.time + ShootDelay;
	        			Shoot();
	        		}
	        	}

	        	if (MyWeaponType == WeaponType.Projectile)
	        	{
	        		print ("drop");
	        		if (Time.time >= nextFire)
	        		{
	        			nextFire = Time.time + ShootDelay;
	        			GameObject temp = Instantiate(ProjectilePrefab, ProjectileSpawner.position, Quaternion.identity);
	        			temp.GetComponent<Rigidbody>().AddForce(ProjectileSpawner.forward * ProjectileForce, ForceMode.VelocityChange);
	        		}
	        		
	        	}

	        	

	        	
	        	
	        	
	        }

	        if (Input.GetMouseButton(0))
	        {
	        	if (MyWeaponType == WeaponType.Auto)
	        	{
	        		if (Time.time >= nextFire)
		        	{
			        	Shoot();
			        	nextFire = Time.time + ShootDelay;
			        	print ("shooting now");
			        	
		        	}
        	
	        	}

	        	if (MyWeaponType == WeaponType.Light)
	        	{
	        		print ("Light");	
	        		Light.SetActive(true);
	        		RaycastHit hit;
		        	if (Physics.Raycast(MyCamera.transform.position, MyCamera.transform.forward, out hit, Mathf.Infinity))
		        	{
		        		if (hit.collider.gameObject.tag == "Screamer")
		        		{
		        			if (hit.collider.gameObject.GetComponent<Scream3Screamer>().GetComponent<MeshRenderer>().enabled)
		        			{
		        				hit.collider.gameObject.GetComponent<Scream3Screamer>().GetDamage(WeaponDamage);
		        			}
		        			
		        		}

		        		if (hit.collider.gameObject.tag == "Creature")
		        		{
		        			
		        			
		        				hit.collider.gameObject.GetComponent<CreatureBehaviour>().GetDamage(WeaponDamage / 1000);
		        			
		        			
		        		}

		        		if (hit.collider.gameObject.tag == "DisDoor")
		        		{
		        			Destroy(hit.collider.gameObject);
		        		}
		        	}
	        	}
	        }
	        else if (Input.GetMouseButtonUp(0))
	        {
	        	Light.SetActive(false);
	        }
    	}
        
    }
}
