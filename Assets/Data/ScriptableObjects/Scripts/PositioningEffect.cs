using UnityEngine;
using UnityEngine.Tilemaps;
public abstract class PositioningEffect : ScriptableObject
{
    public abstract Polymino ApplyEffect(Polymino polymino, Tilemap mainBoard);
}