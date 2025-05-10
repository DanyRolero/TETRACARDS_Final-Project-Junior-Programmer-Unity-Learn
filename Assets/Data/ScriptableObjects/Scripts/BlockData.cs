using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BlockData", menuName = "BlockData", order = 0)]
public class BlockData : ScriptableObject
{
    [SerializeField] Tile tile;
    public Tile Tile {get => tile;}
    [SerializeField] Tile previewTile;
    public Tile PreviewTile {get => previewTile;}
    [SerializeField] BlockEffect blockEffect;
    public BlockEffect BlockEffect {get => blockEffect;}

    //-----------------------------------------------------------------------------
    public override bool Equals(object other)
    {
        if (other is BlockData blockData)
        {
            return tile == blockData.tile && previewTile == blockData.previewTile && blockEffect == blockData.blockEffect;
        }
        return false;
    }
    //-----------------------------------------------------------------------------
    public override int GetHashCode()
    {
        return tile.GetHashCode() ^ previewTile.GetHashCode() ^ blockEffect.GetHashCode();
    }
}