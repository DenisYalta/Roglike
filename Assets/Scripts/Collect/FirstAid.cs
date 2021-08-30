using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstAid : Collect
{
    public Heroes HeroesVariable;

   
    public void UseFirstAid()
    {
        if (CollectAmmounts > 0)
        {
            CollectAmmounts--;
            HeroesVariable.MaxHealth = HeroesVariable.StartHealth;
        }
        else
        {
            Debug.Log("No Aid");
        }
        
    }




}


