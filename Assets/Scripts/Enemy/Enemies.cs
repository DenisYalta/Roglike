using UnityEngine;
using UnityEngine.AI;


public class Enemies : Mobs
{
    public float Damage;
    public float RadiusAttackPlayer;

    protected float DistanceForPlayer;

    
    public Transform EnemyTarget;
    protected NavMeshAgent EnemyAgent;


    protected void FollowPlayer()
    {
        DistanceForPlayer = Vector3.Distance(EnemyTarget.position, transform.position);

        if (DistanceForPlayer<= RadiusAttackPlayer)
        {
            EnemyAgent.SetDestination(EnemyTarget.position);
        }

        if (DistanceForPlayer <= EnemyAgent.stoppingDistance)
        {
            FaceTarget();
        }
    }


    public void FaceTarget()
    {
        Vector3 Direction = (EnemyTarget.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * 5f);
    }


    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusAttackPlayer);
    }

    public void EnemyTakeDamage(float WeaponDamage)
    {
        CurrentHealth -= WeaponDamage;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }


    public void Awake()
    {

        // EnemyTarget = FirstHero.Instance.PlayerHero.transform;
        
         EnemyAgent = GetComponent<NavMeshAgent>();
    }
}


