using System.Collections;
using System.Collections.Generic;

public abstract class FixedTetrominoCollection : PolyminoCollection
{   
    public FixedTetrominoCollection()
    {
        InitializeCollection();  
    }

    //----------------------------------------------------------------
    protected override void InitializeCollection()
    {
        polyminoes = new Tetromino[19];
        polyminoes[0] = new Tetromino(0, 0, 1, 0, 2, 0, 3, 0, IdShape.I);
        polyminoes[1] = new Tetromino(0, 0, 0, 1, 0, 2, 0, 3, IdShape.I);

        polyminoes[2] = new Tetromino(0, 0, 1, 0, 0, 1, 1, 1, IdShape.O);

        polyminoes[3] = new Tetromino(1, 0, 0, 1, 1, 1, 2, 1, IdShape.T);
        polyminoes[4] = new Tetromino(0, 0, 1, 0, 2, 0, 1, 1, IdShape.T);
        polyminoes[5] = new Tetromino(0, 0, 0, 1, 0, 2, 1, 1, IdShape.T);
        polyminoes[6] = new Tetromino(0, 1, 1, 0, 1, 1, 1, 2, IdShape.T);

        polyminoes[7] = new Tetromino(0, 0, 1, 0, 1, 1, 2, 1, IdShape.S);
        polyminoes[8] = new Tetromino(1, 0, 0, 1, 1, 1, 0, 2, IdShape.S);
        
        polyminoes[9] = new Tetromino(1, 0, 2, 0, 0, 1, 1, 1, IdShape.Z);
        polyminoes[10] = new Tetromino(0, 0, 0, 1, 1, 1, 1, 2, IdShape.Z);

        polyminoes[11] = new Tetromino(0, 1, 1, 1, 2, 1, 2, 0, IdShape.J);
        polyminoes[12] = new Tetromino(0, 0, 1, 0, 2, 0, 0, 1, IdShape.J);
        polyminoes[13] = new Tetromino(0, 0, 0, 1, 0, 2, 1, 2, IdShape.J);
        polyminoes[14] = new Tetromino(0, 0, 1, 0, 1, 1, 1, 2, IdShape.J);

        polyminoes[15] = new Tetromino(0, 0, 0, 1, 1, 1, 2, 1, IdShape.L);
        polyminoes[16] = new Tetromino(0, 0, 1, 0, 2, 0, 2, 1, IdShape.L);
        polyminoes[17] = new Tetromino(1, 0, 1, 1, 1, 2, 0, 2, IdShape.L); 
        polyminoes[18] = new Tetromino(0, 0, 1, 0, 0, 1, 0, 2, IdShape.L);
    }
}