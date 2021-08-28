using UnityEngine;
using UnityEngine.AI;


public class Zombie : Enemies
{
    private void Update()
    {
        FollowPlayer();
    }
}
