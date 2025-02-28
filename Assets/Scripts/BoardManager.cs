using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public List<Tile> tiles;
    public Tilemap mainBoard;
    public Tilemap ghostBoard;
    public GameObject grid;
    public int yOrigin;

    private void Start()
    {
        yOrigin = (int)grid.GetComponent<SpriteRenderer>().size.y;
        //mainBoard.SetTile(new Vector3Int(0, yOrigin, 0), tiles[0]);
        //Debug.Log(IsCellOccupied(new Vector3Int(0, 0, 0)));   
    }

    /*
        - Verificar si en una celda del main board existe un tile.
        - Verificar si dado un tetrominó ninguna celda está ocupada
        - Buscar la posición vetical válida más alta para un conjunto de posiciones.
        - Dibujar tiles fantasma en el ghostBoard.
        - Despejar el ghostBoard.
        ------------------------------
        - Dibujar un tetromino en el mainBoard.
        - Eliminar un tile del mainBoard.
        - Eliminar una fila del mainboard.
        - Eliminar varias filas del mainboard.
        - Reposicionar subir una fila.
        --------------------------------
        - Insertar fila según nivel.
    
    */

    //--------------------------------------------------------------------------------
    private bool IsCellOccupied(Vector3Int cell)
    {
        return mainBoard.GetTile(cell) != null;
    }

    //--------------------------------------------------------------------------------
    private bool IsTetrominoColliding(Tetromino tetromino)
    {
        foreach (Vector3Int cell in tetromino.Cells)
        {
            if (IsCellOccupied(cell))
            {
                return true;
            }
        }

        return false;
    }

    //--------------------------------------------------------------------------------
    private Tetromino TrackHighestValidPosition(Tetromino tetromino)
    {
        ClearGhostBoard();
        Tetromino clon = tetromino.Clone();
        clon.Move(new Vector3Int(0, 0 + tetromino.Height, 0));

        while(IsTetrominoColliding(clon))
        {
            clon.Move(new Vector3Int(0, 1, 0));
        }

        return clon;
    }

    //--------------------------------------------------------------------------------
    private void DrawGhostTetromino(Tetromino tetromino)
    {
        foreach (Vector3Int cell in tetromino.Cells)
        {
            ghostBoard.SetTile(cell, tiles[9]);
        }
    }

    //--------------------------------------------------------------------------------
    public void ClearGhostBoard()
    {
        ghostBoard.ClearAllTiles();
    }

    //--------------------------------------------------------------------------------
    public Tetromino PreviewTetrominoInBoard(Tetromino tetromino)
    {
        Tetromino ghostTetromino = TrackHighestValidPosition(tetromino);
        DrawGhostTetromino(ghostTetromino);
        return ghostTetromino;
    }

    //--------------------------------------------------------------------------------
    public void PlaceTetrominoInBoard(Tetromino tetromino, Tile tile)
    {
        foreach (Vector3Int cell in tetromino.Cells)
        {
            mainBoard.SetTile(cell, tile);
        }
    }

}
