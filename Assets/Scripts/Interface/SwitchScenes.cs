using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SwitchScenes : MonoBehaviour
{
    public Animator Transition;

    public static Dictionary <string, int> BaseCollectArray = new Dictionary<string, int>();
    public Dictionary<string, int> ItemsToAdd = new Dictionary<string, int>();


    public Collect Collectable;
    public void OnTriggerEnter(Collider Collision)
    {
        int LevelIndex;
        if (Collision.gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                ItemsToAdd = Collectable.GetBaseResources(); 
                BaseCollectArray = Collectable.UnionDictionaries(ItemsToAdd, BaseCollectArray);  //Union 2 dict


                LevelIndex = -1;
               
                
            }
            else
            {
                LevelIndex = 1;
            }
            StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().buildIndex + LevelIndex));
        }      
    }

   public IEnumerator LoadNextScene(int LevelIndex)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(LevelIndex);
    }


 
}
