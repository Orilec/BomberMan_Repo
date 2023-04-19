using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item[] _spawnableItems;
    [SerializeField] private GlobalManager _globalManager;
    [SerializeField] private float _spawnFrequence;
    private float _spawnTimer;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnFrequence)
        {
            SpawnItem();
            _spawnTimer = 0f;
        }
    }
    private void SpawnItem()
    {
        var xPosition = _globalManager.currentGrid.GetRandomEmptyGridPosition().x;
        var yPosition = _globalManager.currentGrid.GetRandomEmptyGridPosition().y;
        var instance = Instantiate(_spawnableItems[Random.Range(0,_spawnableItems.Length)], new Vector3(xPosition, yPosition, -1f), Quaternion.identity);
        instance.globalManager = _globalManager;
        _globalManager.currentGrid.SetGridElement(xPosition, yPosition, instance.gameObject);
    }
}
