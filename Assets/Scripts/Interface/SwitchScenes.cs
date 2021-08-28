using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public Animator Transition;
    public void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1));
        }      
    }

   public IEnumerator LoadNextScene(int LevelIndex)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(LevelIndex);
    }
}
