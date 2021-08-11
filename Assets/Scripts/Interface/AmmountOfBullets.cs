using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmountOfBullets : MonoBehaviour
{
    public Text BulletsAmmountText;
    public void SetAmmountOfBullets(float CurrentBullets, float MaxBullets)
    {

        BulletsAmmountText.text = CurrentBullets.ToString() + "/" + MaxBullets.ToString();
    }

}
