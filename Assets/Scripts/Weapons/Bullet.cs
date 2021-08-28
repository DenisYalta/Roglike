using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Weapons ShootingWeapon;
    public Enemies HitEnemy;


    public void OnTriggerEnter(Collider Collider)
    {
 
        if (Collider.gameObject.CompareTag("Enemy"))
        {
            
            HitEnemy = Collider.GetComponent<Enemies>();
            HitEnemy.EnemyTakeDamage(ShootingWeapon.Damage);
                
        }
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision Collision)
    {
        Destroy(gameObject);
    }




}
