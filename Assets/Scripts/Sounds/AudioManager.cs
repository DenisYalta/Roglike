using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    
    public Sounds[] ArrayOfSounds;
   

    public static AudioManager Instance; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in ArrayOfSounds)
        {
            s.Sorce = gameObject.AddComponent<AudioSource>();

            s.Sorce.clip = s.Clip;
            s.Sorce.volume = s.Volume;
            s.Sorce.pitch = s.Pitch;
            s.Sorce.loop = s.Loop;



        }
    }


    public void PlaySounds( string NameOfSound)
    {
       Sounds S =  Array.Find(ArrayOfSounds, Sounds => Sounds.Name == NameOfSound);
        if (S == null)
        {

            Debug.LogWarning("Sound: " + name + " not found");
            return;

        }
       S.Sorce.Play();
    
    }
}
