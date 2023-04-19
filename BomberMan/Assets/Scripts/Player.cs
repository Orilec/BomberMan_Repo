using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float invincibilityTime;
    [SerializeField] private bool isInvincible;

    public Color playerColor, hurtColor;
    public Life playerLife;
    public Movement playerMovement;
    public ProgressBar playerLifeBar, playerCooldownBar;
    public BombSpawn playerBombSpawner;
    public BombKick playerKickBomb;
    public GameObject playerEyes;
    public bool itemInEffect, playerKickBombEnabled;

    public void OnHurt(int damages)
    {
        if (!isInvincible)
        {
            playerLife.ChangeLife(damages);
            playerLifeBar.UpdateBar(playerLife.currentLife, playerLife.maxLife);
            StartCoroutine(InvincibilityFrames());
        }
    }

    private IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        _spriteRenderer.color = hurtColor;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
        _spriteRenderer.color = playerColor;
    }

    private void Update()
    {
        playerCooldownBar.UpdateBar(playerBombSpawner.cooldownProgress, playerBombSpawner.cooldownFrames);
    }
}
