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
    public void SetTiles(Card card)
    {
        for (int i = 0; i < card.Polymino.CellsCount; i++)
        {
            previwerBoard.SetTile(card.Polymino[i], card.Blocks[i].PreviewTile);
        }
    }
}
