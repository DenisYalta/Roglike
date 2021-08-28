using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemies
{

    public GameObject ZombiePrefab;
    public Transform SpawnPlace;

    public float SpawnRepeat;

    public void SpawnEnemy()
    {
        GameObject SpawnZombie = Instantiate(ZombiePrefab, SpawnPlace.position, SpawnPlace.rotation);
    }
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", SpawnRepeat, SpawnRepeat);
    }
}
