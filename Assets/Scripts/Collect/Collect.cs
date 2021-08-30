using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    public static float CollectAmmounts = 0f;


    public void OnTriggerEnter(Collider Collider)
    {
        if(Collider.gameObject.CompareTag("Player"))
        {
            CollectAmmounts++;
            Destroy(gameObject);
        }
    }





}
