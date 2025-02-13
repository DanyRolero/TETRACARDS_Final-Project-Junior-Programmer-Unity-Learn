using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : Polymino
{
    public TetrominoTypeShape typeShape { get; private set; }
    public Tetromino(TetrominoTypeShape typeShape) : base(4)
    {
        
    }
}
