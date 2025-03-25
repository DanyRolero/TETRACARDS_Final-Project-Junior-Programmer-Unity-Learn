using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "PositioningEffectData", menuName = "PositioningEffectData", order = 4)]
public abstract class PositioningEffectData : ScriptableObject
{
    public abstract PolyminoData ApplyEffect(PolyminoData polymino, Tilemap mainBoard);
}