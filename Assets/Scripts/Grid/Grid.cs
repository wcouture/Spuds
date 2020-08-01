using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    float width;
    float height;
    float cellSize;

    public static float selectedCell_x;
    public static float selectedCell_y;
    public static GameObject selectedPlane;
    public Grid(float width, float height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
    }

    public void highlightSquare(Vector3 position)
    {
        int x_cell = (int)(Mathf.Floor(position.x / cellSize) * cellSize);
        int y_cell = (int)(Mathf.Floor(position.z / cellSize) * cellSize);
        Debug.Log(x_cell);
        Debug.Log(y_cell);
        Vector3 TopLeft = new Vector3(x_cell,0,y_cell);
        Vector3 TopRight = new Vector3(x_cell + cellSize, 0, y_cell);
        Vector3 BottomRight = new Vector3(x_cell + cellSize,0,y_cell + cellSize);
        Vector3 BottomLeft = new Vector3(x_cell, 0, y_cell + cellSize);

        Debug.DrawLine(TopLeft,TopRight,Color.white,20);
        Debug.DrawLine(BottomLeft,BottomRight,Color.white,20);
        Debug.DrawLine(TopLeft,BottomLeft,Color.white,20);
        Debug.DrawLine(TopRight,BottomRight,Color.white,20);
        
        selectedCell_x = x_cell;
        selectedCell_y = y_cell;
    }

    public void highlightArea(Vector3 square1, Vector3 square2)
    {

    }
}
