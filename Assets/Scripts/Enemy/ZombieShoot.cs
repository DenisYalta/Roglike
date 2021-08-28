using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShoot : Enemies
{
    public float ShootSpeed;
    public float ZombieBulletSpeed;

    public Transform ZombieFirepoint;
    public GameObject ZombieBulletPrefab;

    public void ShootAtPlayer()
    {
        GameObject ZombieBullet = Instantiate(ZombieBulletPrefab, ZombieFirepoint.position, ZombieFirepoint.rotation);
        Rigidbody RigidbodyVariable = ZombieBullet.GetComponent<Rigidbody>();
        RigidbodyVariable.AddForce(ZombieFirepoint.right * ZombieBulletSpeed, ForceMode.Impulse);
    }

    void Start()
    {
        InvokeRepeating("ShootAtPlayer", ShootSpeed, ShootSpeed);
    }

    
    void Update()
    {
        FollowPlayer();
    }
}
