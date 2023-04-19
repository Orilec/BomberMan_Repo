using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTemp : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GlobalManager _globalManager;
    public KeyCode up, down, left, right, bomb, kick;


    private void Update()
    {
        if (!_globalManager.gameEnded)
        {
            if (Input.GetKey(up))
            {
                _player.playerMovement.SimpleMove(Vector3.up);
            }
            if (Input.GetKey(down))
            {
                _player.playerMovement.SimpleMove(Vector3.down);
            }
            if (Input.GetKey(left))
            {
                _player.playerMovement.SimpleMove(Vector3.left);
            }
            if (Input.GetKey(right))
            {
                _player.playerMovement.SimpleMove(Vector3.right);
            }
            if (Input.GetKeyDown(bomb))
            {
                _player.playerBombSpawner.SpawnBomb();
            }
            if (Input.GetKeyDown(kick))
            {
                _player.playerKickBomb.KickBomb();
            }
        }
    }
}
