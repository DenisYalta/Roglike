using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float SpikesDamage = 10;

    public Heroes CollisionHero;
    public Enemies CollisionEnemy;


    public void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            CollisionHero = Collision.GetComponent<Heroes>();
            CollisionHero.IsEnemyHittingHero = true; 
            StartCoroutine(CollisionHero.HeroTakeDamage(SpikesDamage, 0));
        }

        if (Collision.gameObject.CompareTag("Enemy"))
        {
            CollisionEnemy = Collision.GetComponent<Enemies>();
            CollisionEnemy.EnemyTakeDamage(SpikesDamage);
        }
    }        
}
