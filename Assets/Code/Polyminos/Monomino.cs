using UnityEngine;

public class Monomino : Polymino
{
    public Monomino() : base(1, IdShape.O1)
    {
        SetCell(0, new Vector3Int(0, 0, 0));
    }
}