using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviour : MonoBehaviour
{
    public enum MovingType {Small, Scream, Force, Silent, SmallY};
    public MovingType MyMovingType;
    public bool NotKicks;
    public Transform Target;
    public float MovingSpeed;
    public float KickForce;
    public float KickTime;
    public float Health;
    public bool Dead;
    public bool Regenerating;
    public GameObject SpawnedObj;
    public GameObject Particle;
    public AudioSource Scream;
    public AudioClip ScreamSound;
    public AudioClip RespawnSound;
    public AudioClip DamageSound;
    public bool Afraid;
    public bool Spotted;
    public bool Cutscene;
    public Scream5Trigger Trigger;
    private bool isPlaying;
    private bool Kicked;
    private Rigidbody r;
    private Score ScoreObj;
    public float YRespawn;
    public float Damage;

    void Start()
    {
        r = GetComponent<Rigidbody>();
        Kicked = false;
        Target = GameObject.Find("Player").transform;
        ScoreObj = GameObject.Find("Score").GetComponent<Score>();
        isPlaying = false;
        Damage = 5f;
    }

    void Move()
    {
        RaycastHit hit;
        if (MyMovingType == MovingType.Small)
        {
            transform.LookAt(new Vector3(Target.position.x, 1, Target.position.z));
            Vector3 velocity = transform.forward * MovingSpeed;
            if (Afraid)
            {
                if (Health <= 10)
                {
                    transform.LookAt(new Vector3(Target.position.x, 0, Target.position.z));
                    velocity = transform.forward * -MovingSpeed / 10;
                }
                
            }
            r.velocity = velocity;
        }

        if (MyMovingType == MovingType.SmallY)
        {
            transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
            Vector3 velocity = transform.forward * MovingSpeed;
            if (Afraid)
            {
                if (Health <= 10)
                {
                    transform.LookAt(new Vector3(Target.position.x, 0, Target.position.z));
                    velocity = transform.forward * -MovingSpeed / 10;
                }
                
            }
            r.velocity = velocity;
        }

        if (MyMovingType == MovingType.Force && Kicked == false && !Dead)
        {
            StartCoroutine(WaitForce(KickTime));
        }

        if (MyMovingType == MovingType.Scream)
        {
            
            if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, Mathf.Infinity))
            {
                if (Vector3.Distance(Target.position, transform.position) <= 10)
                {
                   if (hit.collider.name == "Player")
                    {
                        transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
                        Vector3 velocity = transform.forward * MovingSpeed;
                        r.velocity = velocity;
                        if (Cutscene)
                        {
                            Trigger.Spotted = true;
                            Trigger.StartCoroutine(Trigger.Spot());
                        }
                        if (!isPlaying)
                        {
                            Scream.PlayOneShot(ScreamSound);
                            isPlaying = true;
                        }
                    } 
                }
                
                
            }

            if (Spotted)
            {
                if (Cutscene)
                {
                    Trigger.Spotted = true;
                    Trigger.StartCoroutine(Trigger.Spot());
                }
                transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
                        Vector3 velocity = transform.forward * MovingSpeed;
                        r.velocity = velocity;
                        if (!isPlaying)
                        {
                            Scream.PlayOneShot(ScreamSound);
                            isPlaying = true;
                        }
            }

            else
            {
                //print ("notPlayer");
            }
        }
        if (MyMovingType == MovingType.Silent)
        {

            if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, Mathf.Infinity))
            {
                print ("Raycast");
                if (hit.collider.name == "Player")
                {

                        transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
                        Vector3 velocity = transform.forward * MovingSpeed;
                        r.velocity = velocity;
                        if (Vector3.Distance(transform.position, Target.position) <= 10)
                        {
                            GetComponent<MeshRenderer>().enabled = true;
                            if (!isPlaying)
                            {
                                Scream.PlayOneShot(ScreamSound);
                                isPlaying = true;
                            }
                        }
                        else
                        {
                            GetComponent<MeshRenderer>().enabled = false;
                        }
                        
                } 
            }
            else
            {
                print ("notPlayer");
            }
        }

        if (Input.GetKeyDown("e"))
        {
            //Attack();
        }
			
    }

    void Update()
    {
        CheckHp();
    	if (!Dead)
        {

           Move(); 
        }
        CheckY();
        
    }

    public void GetDamage(float dmg)
    {
        Health -= dmg;
        if (Cutscene)
            Spotted = true;
    }

    public void Attack()
    {
        //print ("knockback");
        Target.gameObject.GetComponent<WeaponController>().GetDamage(Damage);
        Vector3 delta = (transform.forward - Target.position).normalized * -1;
        Target.gameObject.GetComponent<CharacterController>().Move(delta * Time.deltaTime * 4);
        StartCoroutine(MovePlayer(new Vector3 (2f, 2f, 0f)));
        Scream.PlayOneShot(DamageSound);

    }

    public IEnumerator MovePlayer(Vector3 forceVec)
    {
       float time = 0.5f;
        while (time >= 0){
            Target.gameObject.GetComponent<CharacterController>().Move(forceVec* Time.deltaTime * 4);
            time-=Time.deltaTime;
            yield return null;
        }
        
    }

    void CheckHp()
    {
        if (Health <= 0)
        {
            Dead = true;
            if (Regenerating)
            	Target.gameObject.GetComponent<WeaponController>().GetHeal(2);
            StopCoroutine(WaitForce(KickTime));
            GameObject guts = Instantiate(SpawnedObj);
            GameObject temp = Instantiate(Particle);
            guts.transform.position = transform.position;
            temp.transform.position = transform.position;
            ScoreObj.AddScore(1);
            Destroy(gameObject);
        }
        
    }

    void CheckY()
    {
        Vector3 tempPos = new Vector3(0f, YRespawn, 0f);
        if (transform.position.y <= -40)
        {
            transform.position = Target.position + tempPos;
            r.velocity = new Vector3(0f, 0f, 0f);
            Scream.PlayOneShot(RespawnSound);
        }
    }

    IEnumerator WaitForce(float Wait)
    {
        
        

            if (!Kicked)
            {
                Kicked = true;
                yield return new WaitForSeconds(Wait);
                transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
                r.AddForce(transform.forward * KickForce);
                yield return new WaitForSeconds(Wait);
                Vector3 temp = transform.forward * -1;
                r.AddForce(temp * KickForce / 2);
                yield return new WaitForSeconds(Wait);
                Kicked = false;
            }
            
        
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (MyMovingType != MovingType.SmallY)
        if (col.gameObject.name == "Player")
        {
            print ("collided");
            if (!NotKicks)
            Attack();
        }
    }
    
}
