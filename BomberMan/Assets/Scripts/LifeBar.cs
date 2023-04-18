using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    private float lifePercent;


    public void UpdateLifeBar(int currentLife, int maxLife)
    {
        lifePercent = (float)currentLife / maxLife;
        lifeBar.fillAmount = lifePercent;
    }
}
