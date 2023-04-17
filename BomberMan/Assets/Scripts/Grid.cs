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

    public GameObject ReturnGridElement(int x, int y) {
        return this.gameElementsArray[x, y];
    }

    public void SetGridElement(int x, int y, GameObject gridElement)
    {
        gameElementsArray[x, y] = gridElement;
    }

}
