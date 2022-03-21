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

    static int IndexDifficult = 0;






    public Collect Collectable;
    public void OnTriggerEnter(Collider Collision)
    {
        

        if (Collision.gameObject.CompareTag("Player")) 
        {
            
            IndexDifficult++;

            //case with diff
            // load random scene
            if (SceneManager.GetActiveScene().buildIndex == 1) // going to the base
            {
                ItemsToAdd = Collectable.GetBaseResources(); 
                BaseCollectArray = Collectable.UnionDictionaries(ItemsToAdd, BaseCollectArray);  //Union 2 dict


                IndexDifficult = 0;
               
                
            }
            else
            {
                IndexDifficult = 1;
            }


            StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().buildIndex + IndexDifficult));
        }      
    }

   public IEnumerator LoadNextScene(int IndexDifficult)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(IndexDifficult);
    }

 
       

 
}
