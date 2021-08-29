using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapons
{
    public Transform[] Firepoints;
    public override void SpawnBullets()
    {
       
        base.SpawnBullets();

        Rigidbody RigidbodyVariable;
        GameObject Bullet;
        for (int i = 0; i < Firepoints.Length; i++)
        {
            Bullet = Instantiate(BulletPrefab, Firepoints[i].position, Firepoints[i].rotation);
            RigidbodyVariable = Bullet.GetComponent<Rigidbody>();
            RigidbodyVariable.AddForce(Firepoints[i].right * BulletSpeed, ForceMode.Impulse);
        }
    }
}
