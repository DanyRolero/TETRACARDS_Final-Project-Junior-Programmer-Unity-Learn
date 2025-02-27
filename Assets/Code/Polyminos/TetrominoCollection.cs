using System.Collections;
using System.Collections.Generic;

public class TetrominoCollection
{   
    public Tetromino[] tetrominos { get; private set; }
    public Tetromino this[int index] => tetrominos[index];
    public Dictionary<IdShape, List<Tetromino>> tetrominosByShape { get; private set; }
    public TetrominoCollection()
    {
        InitializeCollection();
        InitializeTetrominosByShape();        
    }

    //----------------------------------------------------------------
    private void InitializeCollection()
    {
        tetrominos = new Tetromino[19];
        
        tetrominos[0] = new Tetromino(0, 0, 1, 0, 2, 0, 3, 0, IdShape.I);
        tetrominos[1] = new Tetromino(0, 0, 0, 1, 0, 2, 0, 3, IdShape.I);

        tetrominos[2] = new Tetromino(0, 0, 1, 0, 0, 1, 1, 1, IdShape.O);

        tetrominos[3] = new Tetromino(0, 0, 1, 0, 2, 0, 1, 1, IdShape.T);
        tetrominos[4] = new Tetromino(1, 0, 0, 1, 1, 1, 2, 1, IdShape.T);
        tetrominos[5] = new Tetromino(0, 0, 0, 1, 0, 2, 1, 1, IdShape.T);
        tetrominos[6] = new Tetromino(0, 1, 1, 0, 1, 1, 1, 2, IdShape.T);

        tetrominos[7] = new Tetromino(1, 0, 2, 0, 0, 1, 1, 1, IdShape.S);
        tetrominos[8] = new Tetromino(0, 0, 0, 1, 1, 1, 1, 2, IdShape.S);

        tetrominos[9] = new Tetromino(0, 0, 1, 0, 1, 1, 2, 1, IdShape.Z);
        tetrominos[10] = new Tetromino(1, 0, 0, 1, 1, 1, 0, 2, IdShape.Z);

        tetrominos[11] = new Tetromino(0, 0, 1, 0, 2, 0, 2, 1, IdShape.J);
        tetrominos[12] = new Tetromino(0, 0, 0, 1, 1, 1, 2, 1, IdShape.J);
        tetrominos[13] = new Tetromino(1, 0, 1, 1, 1, 2, 0, 2, IdShape.J);
        tetrominos[14] = new Tetromino(0, 0, 0, 1, 0, 2, 1, 2, IdShape.J);

        tetrominos[15] = new Tetromino(0, 0, 1, 0, 2, 0, 0, 1, IdShape.L);
        tetrominos[16] = new Tetromino(0, 1, 1, 1, 2, 1, 2, 0, IdShape.L);
        tetrominos[17] = new Tetromino(0, 0, 0, 1, 0, 2, 1, 2, IdShape.L);
        tetrominos[18] = new Tetromino(0, 0, 1, 0, 1, 1, 1, 2, IdShape.L);   
    }

    //----------------------------------------------------------------
    private void InitializeTetrominosByShape()
    {
        tetrominosByShape = new Dictionary<IdShape, List<Tetromino>>();
        foreach (Tetromino tetromino in tetrominos)
        {
            if (!tetrominosByShape.ContainsKey(tetromino.IdShape))
            {
                tetrominosByShape.Add(tetromino.IdShape, new List<Tetromino>());
            }
            tetrominosByShape[tetromino.IdShape].Add(tetromino);
        }
    }
}