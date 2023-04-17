using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    private Grid _grid;
    [SerializeField] private int _gridWidth, _gridHeight;
    public GlobalManager globalManager;
    void Start()
    {
        _grid = new Grid(_gridWidth, _gridHeight);
        CreateBaseGrid();
    }

    public void CreateBaseGrid()
    {
        for (int x = 0; x < _grid.gameElementsArray.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.gameElementsArray.GetLength(1); y++)
            {
                if(x == 0 || y == 0 || x == _grid.gameElementsArray.GetLength(0) - 1 || y == _grid.gameElementsArray.GetLength(1) - 1)
                {
                    var instance = Instantiate(_blockPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                    _grid.SetGridElement(x, y, instance);
                }
                var r = Random.Range(0, 6);
                if(r == 0 && !(x==10 && y==5))
                {
                    var instance = Instantiate(_blockPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                    _grid.SetGridElement(x, y, instance);
                }
            }
        }
        globalManager.currentGrid = _grid;
    }
}
