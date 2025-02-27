using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public List<Tile> tiles;
    public Tilemap mainBoard;
    public Tilemap ghostBoard;
    public int yOrigin;

    private void Start()
    {
        yOrigin = mainBoard.size.y - 1;
        mainBoard.SetTile(new Vector3Int(0, 14, 0), tiles[0]);
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
    private void TrackHighestValidPosition(Tetromino tetromino)
    {
        Tetromino clon = tetromino.Clone();
        clon.Move(new Vector3Int(0, yOrigin, 0));
    }

    //--------------------------------------------------------------------------------
    public void setTetromino(Tetromino tetromino)
    {

        foreach (Vector3Int cell in tetromino.Cells)
        {
            mainBoard.SetTile(cell, tiles[1]);
        }
    }
}
