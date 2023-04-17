using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grid: ThanhMonoBehaviour 
{
    [SerializeField] protected int width, height;
    [SerializeField] private float cellSize;
    [SerializeField] Transform posPoint;
    private int[,] gridArray;
    private void Start()
    {
        this.GenarateGrid(this.width, height, cellSize);
    }
    public void GenarateGrid(int width, int height, float cellSize)
    {
        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Instantiate(posPoint, this.GetBoxPosition(x, y), transform.rotation);
            }
    }
   
    private Vector3 GetBoxPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
    private void GetXY(Vector3 worldPosition,out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }
    private void SetValue(int x,int y, int value)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            gridArray[x, y] = value;  
        }    
    }
    private void SetValue(Vector3 worldPosition,int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }
}
