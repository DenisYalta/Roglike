using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SwitchScenes : MonoBehaviour
{
    public Animator Transition;

    public static Dictionary<string, int> BaseCollectArray = new Dictionary<string, int>();
    public Dictionary<string, int> ItemsToAdd = new Dictionary<string, int>();

    static int IndexDifficult = 0;
    System.Random RandomLevel = new System.Random();

    public  List<int> AllEasyLevels  = new List<int>(); 

    private  static List<int> EasyLevels = new List<int>(); // levels player did not visit
    




    public Collect Collectable;
    public void OnTriggerEnter(Collider Collision)
    {
        

        if (Collision.gameObject.CompareTag("Player")) 
        {

            IndexDifficult++;

            // here should be case but i can not make case working with terms < = >
            if (IndexDifficult == 1) // first level
            {
                EasyLevels = AllEasyLevels;

            
                StartCoroutine(LoadNextScene(EasyLevels[RandomLevel.Next(0, EasyLevels.Count())]));
            }
            else if (IndexDifficult <= 2) // load easy levels
            {

                StartCoroutine(LoadNextScene(EasyLevels[RandomLevel.Next(0, EasyLevels.Count())]));

            }
            else //going to the base
            {
                EasyLevels = AllEasyLevels;
                IndexDifficult = 0;
                ItemsToAdd = Collectable.GetBaseResources();
                BaseCollectArray = Collectable.UnionDictionaries(ItemsToAdd, BaseCollectArray);
                StartCoroutine(LoadNextScene(0));//base
            }

        }      
    }

   public IEnumerator LoadNextScene(int RandomLevelID)
    {

        //  Transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(RandomLevelID);
        EasyLevels.Remove(RandomLevelID);
        Debug.Log(EasyLevels.Count);



    }

    private void Update()
    {
      //  Debug.Log(EasyLevels[RandomLevel.Next(0, EasyLevels.Count())]);
    }

}
