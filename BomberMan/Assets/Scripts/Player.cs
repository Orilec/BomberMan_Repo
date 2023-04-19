using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GlobalManager _globalManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private UIDisplay _UIdisplay;
    [SerializeField] private GameObject _endOfGameUI;
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
    public string playerName;


    public void OnHurt(int damages)
    {
        if (!isInvincible)
        {
            playerLife.ChangeLife(damages);
            playerLifeBar.UpdateBar(playerLife.currentLife, playerLife.maxLife);
            StartCoroutine(InvincibilityFrames());
            if (playerLife.CheckDefeat())
            {
                _UIdisplay.ShowUI(_endOfGameUI);
                _globalManager.players.Remove(this);
                _globalManager.gameEnded = true;
            }
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
