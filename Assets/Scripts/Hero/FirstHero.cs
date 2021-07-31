using UnityEngine;

public class FirstHero : Heroes
{
    public static FirstHero Instance;
    public GameObject PlayerHero;

    public void Awake()
    {
        Instance = this;
    }



    void Update()
    {
        Movement();

        if (MaxHealth > CurrentHealth)
        {
            StartCoroutine ("Regen");
            
        }
      
    }
}
