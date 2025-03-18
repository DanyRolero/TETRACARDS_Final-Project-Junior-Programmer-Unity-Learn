using System;
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
    public Dictionary<String, int> Counters { get; private set; }


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
    // Verifica si una celda del tilemap contiene un tile
    private bool IsCellOccupied(Vector3Int cell)
    {
        return mainBoard.GetTile(cell) != null;
    }

    //--------------------------------------------------------------------------------
    // Verifica si colisiona alguna de las celdas del polymino con alguno de los tiles del tablero
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
    // Registra y mueve un polymino a la fila más alta posible en la que no colisiona con ningún tile
    private Polymino TrackLowestValidPosition(Polymino polymino)
    {
        ClearGhostBoard();

        Polymino clon = polymino.Clone();
        clon.Move(new Vector3Int(0, heightGrid - 1, 0));
        int currentY = heightGrid - 1;

        while (!IsPolyminoColliding(clon))
        {
            if (currentY == 0) return clon;

            clon.Move(new Vector3Int(0, -1, 0));
            currentY--;
        }

        clon.Move(new Vector3Int(0, 1, 0));

        return clon;
    }

    //--------------------------------------------------------------------------------
    // Dibuja en tilemap a partir de un polymino
    private void DrawGhostPolymino(Polymino polymino)
    {
        foreach (Vector3Int cell in polymino.Cells)
        {
            ghostBoard.SetTile(cell, tiles[13]);
        }
    }

    //--------------------------------------------------------------------------------
    // Limpia el tablero de previsión
    public void ClearGhostBoard()
    {
        ghostBoard.ClearAllTiles();
    }

    //--------------------------------------------------------------------------------
    // Despeja el tablero de juego
    public void ClearMainBoard()
    {
        mainBoard.ClearAllTiles();
    }

    //--------------------------------------------------------------------------------
    // Dibuja la posición prevista en el tilemap
    public Polymino PreviewPolyminoInBoard(Polymino polymino)
    {
        Polymino ghostPolymino = TrackLowestValidPosition(polymino);
        DrawGhostPolymino(ghostPolymino);
        return ghostPolymino;
    }

    //--------------------------------------------------------------------------------
    // Dibuja en el tilemap a partir de un polymino dado
    public void PlacePolyminoInBoard(Polymino polymino, Tile tile)
    {
        foreach (Vector3Int cell in polymino.Cells)
        {
            mainBoard.SetTile(cell, tile);
        }
    }

    //--------------------------------------------------------------------------------
    // Verifica si una fila tiene un tila en cada una de sus celdas
    private bool CheckRowIsFull(int row)
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
    private void CountTotalFullRows()
    {
        for (int y = 0; y < heightGrid; y++)
        {
            if (!CheckRowIsFull(y)) continue;
            Counters["Rows"]++;
        }
    }

    public void Recount()
    {
        Counters = new Dictionary<string, int>();
        CountTotalFullRows();
    }

    /*
        - Leer todo el tablero (tras jugar una carta)
        - Contar cuantas filas completas en total -> para combo de filas simultáneas
        - Contar cuantas filas monocolor hay 
        - Contar cuantas filas multicolor hay
        - Verificar si el tablero esta totalmente vacío -> Robo extra
        - Verificar cuantos bloques especiales hay en una fila -> Robo extra
    */

    //--------------------------------------------------------------------------------
    // Borra los tiles de una fila
    private void ClearRow(int row)
    {
        for (int x = 0; x < widthGrid; x++)
        {
            mainBoard.SetTile(new Vector3Int(x, row, 0), null);
        }
    }

    //--------------------------------------------------------------------------------
    // Copia los tiles de una fila
    private void CopyRow(int row)
    {
        rowTiles = new Tile[widthGrid];

        for (int x = 0; x < widthGrid; x++)
        {
            rowTiles[x] = mainBoard.GetTile(new Vector3Int(x, row, 0));
        }
    }

    //--------------------------------------------------------------------------------
    // Dibuja los tiles de la fila guardada
    private void PasteRow(int row)
    {
        for (int x = 0; x < widthGrid; x++)
        {
            mainBoard.SetTile(new Vector3Int(x, row, 0), rowTiles[x]);
        }
    }

    //--------------------------------------------------------------------------------
    // Copia y pega cada fila desde la posición de fila especificada y hacia abajo
    private void MoveRowsDown(int rowStart)
    {
        for (int y = rowStart; y < heightGrid; y++)
        {
            CopyRow(y);
            PasteRow(y - 1);
        }
    }

    //--------------------------------------------------------------------------------
    // Borra las filas que están completas y desplaza hacia abajo las filas que hay por encima
    public void CleanFullRows()
    {
        for (int y = 0; y < heightGrid; y++)
        {
            if (CheckRowIsFull(y))
            {
                MoveRowsDown(y + 1);
                CleanFullRows();
            }
        }
    }
}
