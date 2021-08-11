﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Weapons ShootingWeapon;
    public Enemies HitEnemy;


    public void OnTriggerEnter(Collider Collision)
    {
 
        if (Collision.gameObject.CompareTag("Enemy"))
        {
            
            HitEnemy = Collision.GetComponent<Enemies>();
            HitEnemy.EnemyTakeDamage(ShootingWeapon.Damage);
                
        }
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision Collision)
    {
        Destroy(gameObject);
    }



    void Update()
    {
        
    }
}