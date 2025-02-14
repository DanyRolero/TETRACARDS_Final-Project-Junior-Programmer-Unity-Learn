using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
   public List<Tile> tiles;
   public Tilemap tilemap;

    private void Start() {
        TetrominoColRandomManager tetrominoColRandomManager = new TetrominoColRandomManager();
        Tetromino tetromino = tetrominoColRandomManager.GetRandomTetromino();
        setTetromino(tetromino);

        tilemap.SetTile(new Vector3Int(0, 0, 0), tiles[0]);
    }

        public void setTetromino(Tetromino tetromino)
    {
        
        foreach (Vector3Int cell in tetromino.Cells)
        {
            tilemap.SetTile(cell, tiles[1]);
        }
    }
}
