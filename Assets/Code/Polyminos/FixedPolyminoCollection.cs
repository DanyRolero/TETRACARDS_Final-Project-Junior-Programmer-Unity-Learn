using System.Collections;
using System.Collections.Generic;

public abstract class FixedPolyminoCollection : PolyminoCollection
{
    public FixedPolyminoCollection()
    {
        InitializeCollection();
    }

    //----------------------------------------------------------------
    protected override void InitializeCollection()
    {
        polyminoes = new Polymino[28];

        polyminoes[0] = new Monomino();

        polyminoes[1] = new Domino(0, 0, 1, 0);
        polyminoes[2] = new Domino(0, 0, 0, 1);

        polyminoes[3] = new Tromino(0, 0, 1, 0, 2, 0, IdShape.I3);
        polyminoes[4] = new Tromino(0, 0, 0, 1, 0, 2, IdShape.I3);

        polyminoes[5] = new Tromino(0, 0, 1, 0, 0, 1, IdShape.L3);
        polyminoes[6] = new Tromino(0, 0, 1, 0, 1, 1, IdShape.L3);
        polyminoes[7] = new Tromino(1, 0, 0, 1, 1, 1, IdShape.L3);
        polyminoes[8] = new Tromino(0, 1, 1, 0, 1, 1, IdShape.L3);

        polyminoes[9] = new Tetromino(0, 0, 1, 0, 2, 0, 3, 0, IdShape.I4);
        polyminoes[10] = new Tetromino(0, 0, 0, 1, 0, 2, 0, 3, IdShape.I4);

        polyminoes[11] = new Tetromino(0, 0, 1, 0, 0, 1, 1, 1, IdShape.O4);

        polyminoes[12] = new Tetromino(0, 0, 1, 0, 2, 0, 1, 1, IdShape.T4);
        polyminoes[13] = new Tetromino(1, 0, 0, 1, 1, 1, 2, 1, IdShape.T4);
        polyminoes[14] = new Tetromino(0, 0, 0, 1, 0, 2, 1, 1, IdShape.T4);
        polyminoes[15] = new Tetromino(0, 1, 1, 0, 1, 1, 1, 2, IdShape.T4);

        polyminoes[16] = new Tetromino(0, 0, 1, 0, 1, 1, 2, 1, IdShape.S4);
        polyminoes[17] = new Tetromino(1, 0, 0, 1, 1, 1, 0, 2, IdShape.S4);

        polyminoes[18] = new Tetromino(0, 0, 1, 0, 2, 0, 0, 1, IdShape.J4);
        polyminoes[19] = new Tetromino(0, 1, 1, 1, 2, 1, 2, 0, IdShape.J4);
        polyminoes[20] = new Tetromino(0, 0, 0, 1, 0, 2, 1, 2, IdShape.J4);
        polyminoes[21] = new Tetromino(0, 0, 1, 0, 1, 1, 1, 2, IdShape.J4);

        polyminoes[22] = new Tetromino(1, 0, 2, 0, 0, 1, 1, 1, IdShape.Z4);
        polyminoes[23] = new Tetromino(0, 0, 0, 1, 1, 1, 1, 2, IdShape.Z4);

        polyminoes[24] = new Tetromino(0, 0, 1, 0, 2, 0, 2, 1, IdShape.L4);
        polyminoes[25] = new Tetromino(0, 0, 0, 1, 1, 1, 2, 1, IdShape.L4);
        polyminoes[26] = new Tetromino(0, 0, 1, 0, 0, 1, 0, 2, IdShape.L4);
        polyminoes[27] = new Tetromino(1, 0, 1, 1, 1, 2, 0, 2, IdShape.L4);
    }
}