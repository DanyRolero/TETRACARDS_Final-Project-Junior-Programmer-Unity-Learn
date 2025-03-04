using UnityEngine;

public class Domino : Polymino
{
    public Domino(int x1, int y1, int x2, int y2) : base(2, IdShape.I2)
    {
        SetCell(0, new Vector3Int(0, 0, 0));
        SetCell(1, new Vector3Int(1, 0, 0));
    }
}