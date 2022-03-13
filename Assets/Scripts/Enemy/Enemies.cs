using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class Enemies : Mobs
{
    public float Damage;
    public float Infection;
    public float RadiusAttackPlayer;

    protected float DistanceForPlayer;
    protected bool EnemyAlive = false;

    protected static int NumberOfEnemies = 0;

    public WinState WinStateVariable;

    public GameObject HeroObject;
    public GameObject PlaceForUpgrade;

    protected NavMeshAgent EnemyAgent;





    protected void FollowPlayer()
    {
        DistanceForPlayer = Vector3.Distance(HeroObject.transform.position, transform.position);

        if (DistanceForPlayer<= RadiusAttackPlayer)
        {
            EnemyAgent.SetDestination(HeroObject.transform.position);
        }

        if (DistanceForPlayer <= EnemyAgent.stoppingDistance)
        {
            FaceTarget();
        }
    }


    public void FaceTarget()
    {
        Vector3 Direction = (HeroObject.transform.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    }


    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusAttackPlayer);
    }

    public  void EnemyTakeDamage(float DealedDamage)
    {
       System.Random RandomSoundOnHit = new System.Random();

        CurrentHealth -= DealedDamage;
        FindObjectOfType<AudioManager>().PlaySounds("bullet-hit-body-"+RandomSoundOnHit.Next(1,8));


        if (CurrentHealth <= 0 && EnemyAlive)
        {
            Die();
        }

    }



    public virtual void Die()
    {
       
        EnemyAlive = false;
        NumberOfEnemies--;
        Debug.Log(NumberOfEnemies); 
        Destroy(gameObject);
        
        if (NumberOfEnemies <= 0)
        {
            WinStateVariable.SpawnUpgrade(PlaceForUpgrade.transform.position, PlaceForUpgrade.transform.rotation);
        }
    }


    public void ScreamSounds()
    {
        System.Random ScreamSound = new System.Random();
        FindObjectOfType<AudioManager>().PlaySounds("ZombieScream" + ScreamSound.Next(1, 7));

    }


    public void Awake()
    {


        EnemyAlive = true;
        NumberOfEnemies++;
        HeroObject = GameObject.Find("MainHero");

        PlaceForUpgrade = GameObject.Find("PlaceForUpgrade");


        EnemyAgent = GetComponent<NavMeshAgent>();
        CurrentHealth = StartHealth;

    }
}


