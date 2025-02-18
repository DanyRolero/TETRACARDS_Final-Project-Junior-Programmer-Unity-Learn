using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
   public List<Tile> tiles;
   public Tilemap tilemap;
   public GameObject grid;

    private void Start() 
    {
        tilemap.SetTile(new Vector3Int(0, 0, 0), tiles[0]);
        int columnsInBoard = (int)grid.GetComponent<SpriteRenderer>().size.x;

        RandomNonRepeatedCycleTetromino randomNonRepeatedCycleTetromino = new RandomNonRepeatedCycleTetromino(columnsInBoard);
    }

        public void setTetromino(Tetromino tetromino)
    {
        
        foreach (Vector3Int cell in tetromino.Cells)
        {
            tilemap.SetTile(cell, tiles[1]);
        }
    }
}
