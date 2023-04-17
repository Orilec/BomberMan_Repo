using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTemp : MonoBehaviour
{
    [SerializeField] private Movement _playerMovement;
    [SerializeField]
    private BombSpawn _playerBombspawn;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            _playerMovement.SimpleMove(Vector3.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _playerMovement.SimpleMove(Vector3.down);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _playerMovement.SimpleMove(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _playerMovement.SimpleMove(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerBombspawn.SpawnBomb();
        }
    }

}
