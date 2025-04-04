using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PreviewerBoard : MonoBehaviour
{
    [SerializeField] private Tilemap previwerBoard;

    //--------------------------------------------------------------------------------
    public void SetTile(Vector3Int cell, Tile tile)
    {
        previwerBoard.SetTile(cell, tile);
    }

    //--------------------------------------------------------------------------------
    public void ClearBoard()
    {
        previwerBoard.ClearAllTiles();
    }

    //--------------------------------------------------------------------------------
    public void SetTiles(PlacedBlocks placedBlocks)
    {
        for (int i = 0; i < placedBlocks.Blocks.Length; i++)
        {
            previwerBoard.SetTile(placedBlocks.Positions[i], placedBlocks.Blocks[i].PreviewTile);
        }
    }
}