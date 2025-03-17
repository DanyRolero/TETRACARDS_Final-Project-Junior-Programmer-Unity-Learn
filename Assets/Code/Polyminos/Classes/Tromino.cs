using UnityEngine;

public class Tromino : Polymino
{
    public Tromino(int x1, int y1, int x2, int y2, int x3, int y3, IdShape idShape) : base(3, idShape)
    {
        SetCell(0, new Vector3Int(x1, y1, 0));
        SetCell(1, new Vector3Int(x2, y2, 0));
        SetCell(2, new Vector3Int(x3, y3, 0));
    }
}