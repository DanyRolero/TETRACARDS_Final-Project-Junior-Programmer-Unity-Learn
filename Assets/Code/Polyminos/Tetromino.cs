using UnityEngine;

public class Tetromino
{   public int Id {get; private set;}
    private static int idCount = 0;
    public IdShape IdShape {get; private set;}
    public Vector3Int[] Cells {get; private set;}
    public int Length => Cells.Length;
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
    public Tetromino(int x0, int y0, int x1, int y1, int x2, int y2, int x3, int y3, IdShape idShape)
    {
        Cells = new Vector3Int[4];
        SetCell(0, new Vector3Int(x0, y0, 0));
        SetCell(1, new Vector3Int(x1, y1, 0));
        SetCell(2, new Vector3Int(x2, y2, 0));
        SetCell(3, new Vector3Int(x3, y3, 0));
        IdShape = idShape;
        Id = idCount++;
    }

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

}
