using UnityEngine;
using UnityEngine.AI;


public class Zombie : Enemies
{
    void Update()
    {
        FollowPlayer();
    }
}
