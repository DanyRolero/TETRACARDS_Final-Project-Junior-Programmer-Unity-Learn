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
    public int yOrigin = 0;

    private void Start()
    {
        yOrigin = (int)grid.GetComponent<SpriteRenderer>().size.y - 1;
        //mainBoard.SetTile(new Vector3Int(0, yOrigin, 0), tiles[0]);
        //Debug.Log(IsCellOccupied(new Vector3Int(0, 0, 0)));   
    }

    /*
        - Eliminar un tile del mainBoard.
        - Eliminar una fila del mainboard.
        - Eliminar varias filas del mainboard.
        - subir filas
        - bajar filas
        --------------------------------
        - Insertar fila según nivel.
    
    */

    //--------------------------------------------------------------------------------
    private bool IsCellOccupied(Vector3Int cell)
    {
        return mainBoard.GetTile(cell) != null;
    }

    //--------------------------------------------------------------------------------
    private bool IsPolyminoColliding(Polymino polymino)
    {
        foreach (Vector3Int cell in polymino.Cells)
        {
            if (IsCellOccupied(cell))
            {
                return true;
            }
        }

        return false;
    }

    //--------------------------------------------------------------------------------
    private Polymino TrackLowestValidPosition(Polymino polymino)
    {
        ClearGhostBoard();
        
        Polymino clon = polymino.Clone();
        clon.Move(new Vector3Int(0, yOrigin, 0));
        int currentY = yOrigin;

        while(!IsPolyminoColliding(clon))
        {
            if(currentY == 0) return clon;

            clon.Move(new Vector3Int(0, -1, 0));
            currentY--;
        }

        clon.Move(new Vector3Int(0, 1, 0));

        return clon;
    }

    //--------------------------------------------------------------------------------
    private void DrawGhostPolymino(Polymino polymino)
    {
        foreach (Vector3Int cell in polymino.Cells)
        {
            ghostBoard.SetTile(cell, tiles[13]);
        }
    }

    //--------------------------------------------------------------------------------
    public void ClearGhostBoard()
    {
        ghostBoard.ClearAllTiles();
    }

    //--------------------------------------------------------------------------------
    public Polymino PreviewPolyminoInBoard(Polymino polymino)
    {
        Polymino ghostPolymino = TrackLowestValidPosition(polymino);
        DrawGhostPolymino(ghostPolymino);
        return ghostPolymino;
    }

    //--------------------------------------------------------------------------------
    public void PlacePolyminoInBoard(Polymino polymino, Tile tile)
    {
        foreach (Vector3Int cell in polymino.Cells)
        {
            mainBoard.SetTile(cell, tile);
        }
    }

    //--------------------------------------------------------------------------------
    private bool CheckRowIsFull(int row)
    {
        for (int x = 0; x < mainBoard.size.x; x++)
        {
            if (!IsCellOccupied(new Vector3Int(x, row, 0)))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    private void ClearRow(int row)
    {
        for (int x = 0; x < mainBoard.size.x; x++)
        {
            mainBoard.SetTile(new Vector3Int(x, row, 0), null);
        }
    }

    //--------------------------------------------------------------------------------
    private void RowMoveDown(int row) 
    {
        // copiar tiles de la fila (copiar fila)
        // eliminar fila original
    }

}
