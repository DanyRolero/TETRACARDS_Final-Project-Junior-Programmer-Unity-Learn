using UnityEngine;

public abstract class Polymino
{
    private Vector3Int[] _cells;

    public Vector3Int[] Cells
    {
        get { return _cells; }
    }
    public Vector3Int[] Units
    {
        get { return _cells; }
    }
    public int Length => _cells.Length;
    public int MinX => _MinX();
    public int MaxX => _MaxX();
    public int Width => MaxX - MinX + 1;
    public int MinY => _MinY();
    public int MaxY => _MaxY();
    public int Height => MaxY - MinY + 1;
    public int MinZ => _MinZ();
    public int MaxZ => _MaxZ();
    public int Depth => MaxZ - MinZ + 1;


    public Vector3Int this[int index] => _cells[index];

    //----------------------------------------------------------------
    public Polymino(int amountOfUnits)
    {
        _cells = new Vector3Int[amountOfUnits];
    }

    //----------------------------------------------------------------
    public void SetUnit(int index, Vector3Int unit)
    {
        _cells[index] = unit;
    }

    //----------------------------------------------------------------
    private int _MinX() 
    {
        int minX = _cells[0].x;
        foreach (Vector3Int unit in _cells)
        {
            if (unit.x < minX)
            {
                minX = unit.x;
            }
        }
        return minX;
    }

    //----------------------------------------------------------------
    private int _MaxX()
    {
        int maxX = _cells[0].x;
        foreach (Vector3Int unit in _cells)
        {
            if (unit.x > maxX)
            {
                maxX = unit.x;
            }
        }
        return maxX;
    }

    //----------------------------------------------------------------
    private int _MinY() 
    {
        int minY = _cells[0].y;
        foreach (Vector3Int unit in _cells)
        {
            if (unit.y < minY)
            {
                minY = unit.y;
            }
        }
        return minY;
    }

    //----------------------------------------------------------------
    private int _MaxY()
    {
        int maxY = _cells[0].y;
        foreach (Vector3Int unit in _cells)
        {
            if (unit.y > maxY)
            {
                maxY = unit.y;
            }
        }
        return maxY;
    }

    //----------------------------------------------------------------
    private int _MinZ() 
    {
        int minZ = _cells[0].z;
        foreach (Vector3Int unit in _cells)
        {
            if (unit.z < minZ)
            {
                minZ = unit.z;
            }
        }
        return minZ;
    }

    //----------------------------------------------------------------
    private int _MaxZ()
    {
        int maxZ = _cells[0].z;
        foreach (Vector3Int unit in _cells)
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
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i] += direction;
        }
    }

}
