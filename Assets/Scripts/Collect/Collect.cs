using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    public static Dictionary<string, int> CollectArray = new Dictionary<string, int>();


    public void OnTriggerEnter(Collider Collider)
    { 
        if(Collider.gameObject.CompareTag("Player"))
        {
            if (CollectArray.ContainsKey(gameObject.name))
            {
                CollectArray[gameObject.name]++;
                Debug.Log("I have it");
            }
            else
            {
                Debug.Log("Added");
                CollectArray.Add(gameObject.name, 1);
            }
            Destroy(gameObject);
        }
    }

}
