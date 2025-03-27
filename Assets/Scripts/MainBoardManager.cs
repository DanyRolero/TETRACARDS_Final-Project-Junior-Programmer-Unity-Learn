using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainBoardManager : MonoBehaviour
{
    [SerializeField] private Tilemap mainBoard;

    //--------------------------------------------------------------------------------
    public void SetTile(Vector3Int cell, BlockData blockData)
    {
        TileBase tile = mainBoard.GetTile(cell);
        mainBoard.SetTile(cell, blockData.Tile);
    }

    //--------------------------------------------------------------------------------
    public void ClearBoard()
    {
        mainBoard.ClearAllTiles();
    }

    //--------------------------------------------------------------------------------
    public void SetBoard(BlockData[,] blocksGrid)
    {
        for (int x = 0; x < blocksGrid.GetLength(0); x++)
        {
            for (int y = 0; y < blocksGrid.GetLength(1); y++)
            {
                BlockData blockData = blocksGrid[x, y];
                if (blockData != null)
                {
                    Vector3Int cell = new Vector3Int(x, y, 0);
                    SetTile(cell, blockData);
                }
            }
        }
    }
}
