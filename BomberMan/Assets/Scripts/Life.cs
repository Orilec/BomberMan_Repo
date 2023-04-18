using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxLife;
    public int currentLife;
    void Start()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        currentLife = maxLife;
    }

    public void ChangeLife(int amount)
    {
        currentLife += amount;
    }

}
