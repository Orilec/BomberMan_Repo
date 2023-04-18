using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    [SerializeField] private Movement _bombSpawnerMovement;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private bool _cooldown;

    public float cooldownFrames, cooldownProgress;
    public GlobalManager globalManager;

   public void SpawnBomb() {
        if (!_cooldown)
        {
            if (globalManager.currentGrid.gameElementsArray[_bombSpawnerMovement.PositionOnGrid()[0], _bombSpawnerMovement.PositionOnGrid()[1]] == null)
            {
                StartCoroutine(Cooldown()); 
                var instance = Instantiate(_bombPrefab, new Vector3(_bombSpawnerMovement.PositionOnGrid()[0], _bombSpawnerMovement.PositionOnGrid()[1], -1), Quaternion.identity);
                globalManager.currentGrid.SetGridElement(_bombSpawnerMovement.PositionOnGrid()[0], _bombSpawnerMovement.PositionOnGrid()[1], instance.gameObject);
                instance.globalManager = globalManager;
            }
        }
    }

    private IEnumerator Cooldown()
    {
        cooldownProgress = 0;
        _cooldown = true;
        while(cooldownProgress < cooldownFrames)
        {
            cooldownProgress++;
            yield return new WaitForEndOfFrame();
        }
        _cooldown = false;
        yield break;
    }
}
