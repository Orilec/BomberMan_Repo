using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    private int _gridWidth, _gridHeight;
    public GameObject[,] gameElementsArray;

    public Grid(int gridWidth, int gridHeight)
    {
        _gridWidth = gridWidth;
        _gridHeight = gridHeight;
        gameElementsArray = new GameObject[gridWidth, gridHeight];
    }

    public GameObject ReturnGridElementAtPosition(int x, int y) {
        return this.gameElementsArray[x, y];
    }

    public void SetGridElement(int x, int y, GameObject gridElement)
    {
        gameElementsArray[x, y] = gridElement;
    }

    public Vector2Int GetRandomEmptyGridPosition()
    {
        var x = Random.Range(0, _gridWidth);
        var y = Random.Range(0, _gridHeight);
        while (ReturnGridElementAtPosition(x, y)!= null)
        {
            x = Random.Range(0, _gridWidth);
            y = Random.Range(0, _gridHeight);
        }
        return new Vector2Int(x, y);
    }
}
