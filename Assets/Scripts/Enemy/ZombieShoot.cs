using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShoot : Enemies
{
    public float ShootSpeed;
    public float ZombieBulletSpeed;

    public Transform [] ZombieFirepoints;
    public GameObject ZombieBulletPrefab;

    public void ShootAtPlayer()
    {
        GameObject ZombieBullet;
        Rigidbody RigidbodyVariable;
        for (int i=0; i< ZombieFirepoints.Length; i++)
        {
            ZombieBullet = Instantiate(ZombieBulletPrefab, ZombieFirepoints[i].position, ZombieFirepoints[i].rotation);
            RigidbodyVariable = ZombieBullet.GetComponent<Rigidbody>();
            RigidbodyVariable.AddForce(ZombieFirepoints[i].right * ZombieBulletSpeed, ForceMode.Impulse);
        }

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
