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

    public Dictionary<string, int> UnionDictionaries(Dictionary<string, int>  Inventory, Dictionary<string, int> Base)
    {
        foreach (KeyValuePair<string, int> InventoryItem in Inventory) 
        {
            
            if (Base.ContainsKey(InventoryItem.Key))
            {
                Base[InventoryItem.Key]++;
            }
            else
            {
                Base.Add(InventoryItem.Key, InventoryItem.Value);
            }
        }

        return Base;
    }

}
