using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Polymino", menuName = "Polymino", order = 0)]
public class PolyminoData : ScriptableObject
{
    public IdShape idShape;
    public Vector3Int[] Cells;

    public int CellsCount => Cells.Length;
    public int MinX => CalculateMinX();
    public int MaxX => CalculateMaxX();
    public int Width => MaxX - MinX + 1;
    public int MinY => CalculateMinY();
    public int MaxY => CalculateMaxY();
    public int Height => MaxY - MinY + 1;
    public int MinZ => CalculateMinZ();
    public int MaxZ => CalculateMaxZ();
    public int Depth => MaxZ - MinZ + 1;

    public Vector3Int this[int index] => Cells[index];

    //----------------------------------------------------------------
    protected void SetCell(int index, Vector3Int cell)
    {
        Cells[index] = cell;
    }

    //----------------------------------------------------------------
    private int CalculateMinX() 
    {
        int minX = Cells[0].x;
        foreach (Vector3Int unit in Cells)
        {
            if (unit.x < minX)
            {
                minX = unit.x;
            }
        }
        return minX;
    }

    //----------------------------------------------------------------
    private int CalculateMaxX()
    {
        int maxX = Cells[0].x;
        foreach (Vector3Int unit in Cells)
        {
            if (unit.x > maxX)
            {
                maxX = unit.x;
            }
        }
        return maxX;
    }

    //----------------------------------------------------------------
    private int CalculateMinY() 
    {
        int minY = Cells[0].y;
        foreach (Vector3Int unit in Cells)
        {
            if (unit.y < minY)
            {
                minY = unit.y;
            }
        }
        return minY;
    }

    //----------------------------------------------------------------
    private int CalculateMaxY()
    {
        int maxY = Cells[0].y;
        foreach (Vector3Int unit in Cells)
        {
            if (unit.y > maxY)
            {
                maxY = unit.y;
            }
        }
        return maxY;
    }

    //----------------------------------------------------------------
    private int CalculateMinZ() 
    {
        int minZ = Cells[0].z;
        foreach (Vector3Int unit in Cells)
        {
            if (unit.z < minZ)
            {
                minZ = unit.z;
            }
        }
        return minZ;
    }

    //----------------------------------------------------------------
    private int CalculateMaxZ()
    {
        int maxZ = Cells[0].z;
        foreach (Vector3Int unit in Cells)
        {
            if (unit.z > maxZ)
            {
                maxZ = unit.z;
            }
        }
        return maxZ;
    }

    //----------------------------------------------------------------
    public void Move(Vector3Int direction)
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i] += direction;
        }
    }

    //----------------------------------------------------------------
    public PolyminoData Clone()
    {
        PolyminoData clone = (PolyminoData)MemberwiseClone();
        clone.idShape = idShape;
        clone.Cells = new Vector3Int[Cells.Length];
        
        for (int i = 0; i < Cells.Length; i++)
        {
            clone.Cells[i] = Cells[i];
        }
        return clone;
    }
}
