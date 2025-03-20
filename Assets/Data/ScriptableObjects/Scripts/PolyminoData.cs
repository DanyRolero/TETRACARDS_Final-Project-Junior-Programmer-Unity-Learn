using UnityEngine;

[CreateAssetMenu(fileName = "PolyminoData", menuName = "PolyminoData", order = 0)]
public class PolyminoData : ScriptableObject
{
    public IdShape IdShape {get; private set;}
    public Vector3Int[] Cells {get; private set;}
}