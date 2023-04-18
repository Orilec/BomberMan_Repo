using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Life playerLife;
    public Movement playerMovement;
    public LifeBar playerLifeBar;
    public BombSpawn playerBombSpawner;

    public void OnHurt(int damages)
    {
        playerLife.ChangeLife(damages);
        playerLifeBar.UpdateLifeBar(playerLife.currentLife, playerLife.maxLife);
    }
}
