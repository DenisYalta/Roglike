using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    public static Dictionary<string, int> CollectArray = new Dictionary<string, int>(); //Items Player Collected



    public void OnTriggerEnter(Collider Collider)
    { 
        if(Collider.gameObject.CompareTag("Player"))
        {
            AddNewItems();
            Destroy(gameObject);
        }
        
    }


    public Dictionary <string, int> GetBaseResources()
    {
        Dictionary<string, int> AddedItemsToTheBase = new Dictionary<string, int>(CollectArray);
        CollectArray.Clear();
        return AddedItemsToTheBase;
    }

    public void AddNewItems()
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
    }

    public Dictionary<string, int> UnionDictionaries(Dictionary<string, int>  Dict1, Dictionary<string, int> Dict2)
    {
        foreach (KeyValuePair<string, int> item1 in Dict1) 
        {
            
            if (Dict2.ContainsKey(item1.Key))
            {
                Dict2[item1.Key]++;
            }
            else
            {
                Dict2.Add(item1.Key, item1.Value);
            }
        }

        return Dict2;
    }

}
