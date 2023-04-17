using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    [SerializeField] private Movement _bombSpawnerMovement;
    public GlobalManager globalManager;
    [SerializeField] private Bomb _bombPrefab;

   public void SpawnBomb() { 
        if(globalManager.currentGrid.gameElementsArray[_bombSpawnerMovement.PositionOnGrid()[0], _bombSpawnerMovement.PositionOnGrid()[1]] == null)
        {
            var instance = Instantiate(_bombPrefab, new Vector3(_bombSpawnerMovement.PositionOnGrid()[0], _bombSpawnerMovement.PositionOnGrid()[1], -1), Quaternion.identity);
            globalManager.currentGrid.SetGridElement(_bombSpawnerMovement.PositionOnGrid()[0], _bombSpawnerMovement.PositionOnGrid()[1], instance.gameObject);
            instance.globalManager = globalManager;
        }
        else {
            Debug.Log("There's already a bomb");
        }
    }

}
