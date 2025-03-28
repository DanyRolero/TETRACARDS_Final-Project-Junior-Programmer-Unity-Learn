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
    public void SetTiles(BlockData[] blocks)
    {

    }
}
