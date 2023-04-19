using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private Destructible _destructiblePrefab;
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

                // creates blocks on the edge of the grid
                if (x == 0 || y == 0 || x == _grid.gameElementsArray.GetLength(0) - 1 || y == _grid.gameElementsArray.GetLength(1) - 1)
                {
                    var instance = Instantiate(_blockPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                    _grid.SetGridElement(x, y, instance);
                }
                else
                {
                    var xInsideRange = x > 7 && x < 13;
                    var yInsideRange = y > 3 && y < 7;
                    if (!(xInsideRange && yInsideRange)) // lets central space for player spawn
                    {
                        var r = Random.Range(0, 6);
                        if (r == 0) //spawn random blocks
                        {
                            var instance = Instantiate(_blockPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                            _grid.SetGridElement(x, y, instance);
                        }
                        else
                        {
                            if (r > 3 && !(x == 10 && y == 5)) //spawn random destructibles
                            {
                                var instance = Instantiate(_destructiblePrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
                                _grid.SetGridElement(x, y, instance.gameObject);
                            }
                        }
                    }
                }
            }
        }
        globalManager.currentGrid = _grid; //sends grid to global manager so other classes can access it
    }
}
