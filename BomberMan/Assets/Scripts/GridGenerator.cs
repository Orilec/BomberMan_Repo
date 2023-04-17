using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private Grid _grid;
    [SerializeField] private int _gridWidth, _gridHeight;
    void Start()
    {
        _grid = new Grid(_gridWidth, _gridHeight);
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateGrid()
    {
        for (int x = 0; x < _grid.gameElementsArray.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.gameElementsArray.GetLength(1); y++)
            {
                var r = Random.Range(0, 2);
                if(r == 0)
                {
                    var instance = Instantiate(_blockPrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }
}
