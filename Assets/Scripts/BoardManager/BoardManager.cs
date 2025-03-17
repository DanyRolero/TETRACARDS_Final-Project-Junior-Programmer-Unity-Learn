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
    public int heightGrid;
    public int widthGrid;
    private TileBase[] rowTiles;


    //--------------------------------------------------------------------------------
    public void Initialize(Vector2Int size)
    {
        widthGrid = size.x;
        heightGrid = size.y;

        grid.GetComponent<SpriteRenderer>().size = size;


        float xOffset = size.x / -2 + 0.5f;
        float yOffset = size.y / -2;

        mainBoard.GetComponent<Tilemap>().tileAnchor = new Vector3(xOffset, yOffset, 0);
        ghostBoard.GetComponent<Tilemap>().tileAnchor = new Vector3(xOffset, yOffset, 0);
    }
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
        clon.Move(new Vector3Int(0, heightGrid - 1, 0));
        int currentY = heightGrid - 1;

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
    public void ClearMainBoard()
    {
        mainBoard.ClearAllTiles();
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
    public bool CheckRowIsFull(int row)
    {
        for (int x = 0; x < widthGrid; x++)
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
        for (int x = 0; x < widthGrid; x++)
        {
            mainBoard.SetTile(new Vector3Int(x, row, 0), null);
        }
    }

    //--------------------------------------------------------------------------------
    private void CopyRow(int row) 
    {
        rowTiles = new Tile[widthGrid];

        for (int x = 0; x < widthGrid; x++)
        {
            rowTiles[x] = mainBoard.GetTile(new Vector3Int(x, row, 0));
        }
    }

    //--------------------------------------------------------------------------------
    private void PasteRow(int row)
    {
        for (int x = 0; x < widthGrid; x++)
        {
            mainBoard.SetTile(new Vector3Int(x, row, 0), rowTiles[x]);
        }
    }

    //--------------------------------------------------------------------------------
    public void MoveRowsDown(int rowStart)
    {
        for (int y = rowStart; y < heightGrid; y++)
        {
            CopyRow(y);
            PasteRow(y-1);
        }
    }

    //--------------------------------------------------------------------------------
    public void CleanFullRows()
    {
        for (int y = 0; y < heightGrid; y++)
        {
            if (CheckRowIsFull(y))
            {
                MoveRowsDown(y+1);
                CleanFullRows();
            }
        }
    }
}
