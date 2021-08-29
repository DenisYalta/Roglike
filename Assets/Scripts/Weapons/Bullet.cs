using UnityEngine;

public class Bullet : MonoBehaviour
{


    public Enemies HitEnemy;
    public float Damage;


    public void OnTriggerEnter(Collider Collider)
    {
 
        if (Collider.gameObject.CompareTag("Enemy"))
        {
            
            HitEnemy = Collider.GetComponent<Enemies>();
            HitEnemy.EnemyTakeDamage(Damage);
                
        }
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision Collision)
    {
        Destroy(gameObject);
    }



}
