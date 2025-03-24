using UnityEngine;

[CreateAssetMenu(fileName = "PolyminoData", menuName = "PolyminoData", order = 1)]
public class PolyminoData : ScriptableObject
{
    [SerializeField] IdShape IDForma;
    public IdShape IdShape {get; private set;}

    [SerializeField] Vector3Int[] cells;
    public Vector3Int[] Cells {get; private set;}
}