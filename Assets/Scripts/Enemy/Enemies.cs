using UnityEngine;
using UnityEngine.AI;


public class Enemies : Mobs
{
    public float Damage;
    public float Infection;
    public float RadiusAttackPlayer;
    

    protected float DistanceForPlayer;

    private System.Random RandomSoundOnHit = new System.Random();

    public GameObject HeroObject;
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
       

        CurrentHealth -= DealedDamage;

        FindObjectOfType<AudioManager>().PlaySounds("bullet-hit-body-"+RandomSoundOnHit.Next(1,8));
        if (CurrentHealth <= 0)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }


    public void Awake()
    {
        HeroObject = GameObject.Find("MainHero");

        EnemyAgent = GetComponent<NavMeshAgent>();
        CurrentHealth = StartHealth;

    }
}


