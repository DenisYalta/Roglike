using UnityEngine;

public class ZombieBullet : MonoBehaviour
{

    public Enemies ShootingEnemy;
    public Heroes HitHero;

    public void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            HitHero = Collision.collider.GetComponent<Heroes>();
            HitHero.IsEnemyHittingHero = true;
            StartCoroutine(HitHero.HeroTakeDamage(ShootingEnemy.Damage, ShootingEnemy.Infection));
        }
            Destroy(gameObject);
    }




}
