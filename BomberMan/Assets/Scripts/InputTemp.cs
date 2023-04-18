using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTemp : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            _player.playerMovement.SimpleMove(Vector3.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _player.playerMovement.SimpleMove(Vector3.down);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _player.playerMovement.SimpleMove(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _player.playerMovement.SimpleMove(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.playerBombSpawner.SpawnBomb();
        }
    }

}
