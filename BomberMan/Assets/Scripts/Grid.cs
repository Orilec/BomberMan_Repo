using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    private int _gridWidth, _gridHeight;
    public GameObject[,] gameElementsArray;

    public Grid(int gridWidth, int gridHeight)
    {
        this._gridWidth = gridWidth;
        this._gridHeight = gridHeight;
        this.gameElementsArray = new GameObject[gridWidth, gridHeight];
    }

}
