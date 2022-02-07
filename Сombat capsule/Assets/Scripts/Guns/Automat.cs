using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public int numberOfBullets;
    public Text bulletsText;
    public PlayerArmory playerArmory;

    public override void Shot()
    {
        base.Shot();
        numberOfBullets -= 1;
        UpdateText();

        if (numberOfBullets == 0)
        {
            playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        bulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        bulletsText.enabled = false;
    }

    private void UpdateText()
    {
        bulletsText.text = "Bullets: " + numberOfBullets.ToString();
    }

    public override void AddBullets(int numberOfBulletsToAdd)
    {
        base.AddBullets(numberOfBulletsToAdd);
        numberOfBullets += numberOfBulletsToAdd;
        UpdateText();
        playerArmory.TakeGunByIndex(1);
    }
}
