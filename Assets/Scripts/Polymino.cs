using UnityEngine;

public abstract class Polymino
{
    private Vector3Int[] _units;
    public Vector3Int[] Units
    {
        get { return _units; }
    }
    public int Length => _units.Length;
    public int MinX => _MinX();
    public int MaxX => _MaxX();
    public int Width => MaxX - MinX;
    public int MinY => _MinY();
    public int MaxY => _MaxY();
    public int Height => MaxY - MinY;
    public int MinZ => _MinZ();
    public int MaxZ => _MaxZ();
    public int Depth => MaxZ - MinZ;


    public Vector3Int this[int index] => _units[index];

    //----------------------------------------------------------------
    public Polymino(int amountOfUnits)
    {
        _units = new Vector3Int[amountOfUnits];
    }

    //----------------------------------------------------------------
    public void SetUnit(int index, Vector3Int unit)
    {
        _units[index] = unit;
    }

    //----------------------------------------------------------------
    private int _MinX() 
    {
        int minX = _units[0].x;
        foreach (Vector3Int unit in _units)
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
        int maxX = _units[0].x;
        foreach (Vector3Int unit in _units)
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
        int minY = _units[0].y;
        foreach (Vector3Int unit in _units)
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
        int maxY = _units[0].y;
        foreach (Vector3Int unit in _units)
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
        int minZ = _units[0].z;
        foreach (Vector3Int unit in _units)
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
        int maxZ = _units[0].z;
        foreach (Vector3Int unit in _units)
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
        for (int i = 0; i < _units.Length; i++)
        {
            _units[i] += direction;
        }
    }

}
