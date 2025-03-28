using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainBoardManager : MonoBehaviour
{
    [SerializeField] private Tilemap mainBoard;

    //--------------------------------------------------------------------------------
    public void SetTile(Vector3Int cell,Tile tile)
    {
        mainBoard.SetTile(cell, tile);
    }

    //--------------------------------------------------------------------------------
    public void ClearBoard()
    {
        mainBoard.ClearAllTiles();
    }

    //--------------------------------------------------------------------------------
    public void SetBoard(Tile[,] tiles)
    {
        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                Vector3Int cell = new Vector3Int(x, y, 0);
                SetTile(cell, tiles[x, y]);
            }
        }
    }
}
