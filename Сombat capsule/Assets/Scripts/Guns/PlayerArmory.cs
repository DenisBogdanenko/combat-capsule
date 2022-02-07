using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] guns;
    public int currentGunIndex;

    void Start()
    {
        TakeGunByIndex(currentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        currentGunIndex = gunIndex;
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == gunIndex)
            {
                guns[i].Activate();
            }
            else
            {
                guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        guns[gunIndex].AddBullets(numberOfBullets);
    }
}
