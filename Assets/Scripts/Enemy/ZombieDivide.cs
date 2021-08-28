using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDivide : Enemies
{
    public GameObject ZombieDividePrefab;
    public Transform RightZombie;
    public Transform LeftZombie;
    public override void Die()
    {
        base.Die();
        GameObject DividedZombie = Instantiate(ZombieDividePrefab, RightZombie.position, RightZombie.rotation);
        DividedZombie = Instantiate(ZombieDividePrefab, LeftZombie.position, LeftZombie.rotation);
    }


    private void Update()
    {
        FollowPlayer();
    }

}
