using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : Polymino
{
    static private int idCounter = 0;
    public int id { get; private set; }
    public TetrominoTypeShape tetrominoTypeShape { get; private set; }
    public Tetromino(int x0, int y0, int x1, int y1, int x2, int y2, int x3, int y3, TetrominoTypeShape typeShape) : base(4)
    {
        id = idCounter++;
        tetrominoTypeShape = typeShape;
        
        this._cells[0] = new Vector3Int(x0, y0, 0);
        this._cells[1] = new Vector3Int(x1, y1, 0);
        this._cells[2] = new Vector3Int(x2, y2, 0);
        this._cells[3] = new Vector3Int(x3, y3, 0);
    }
}
