using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoCollection
{
    public List<Tetromino> tetrominos { get; private set; }
    public Dictionary<TetrominoTypeShape, List<Tetromino>> tetrominosByTypeShape { get; private set; }


    public TetrominoCollection()
    {
        tetrominos = new List<Tetromino>();

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 0, 3, 0, TetrominoTypeShape.I));
        tetrominos.Add(new Tetromino(0, 0, 0, 1, 0, 2, 0, 3, TetrominoTypeShape.I));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 0, 1, 1, 1, TetrominoTypeShape.O));

        tetrominos.Add(new Tetromino(0, 0, 0, 1, 1, 1, 0, 2, TetrominoTypeShape.T));
        tetrominos.Add(new Tetromino(1, 0, 0, 1, 1, 1, 1, 2, TetrominoTypeShape.T));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 1, 1, 1, TetrominoTypeShape.T));
        tetrominos.Add(new Tetromino(1, 0, 0, 1, 1, 1, 2, 1, TetrominoTypeShape.T));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 1, 1, 2, 1, TetrominoTypeShape.S));
        tetrominos.Add(new Tetromino(1, 0, 0, 1, 1, 1, 0, 2, TetrominoTypeShape.S));

        tetrominos.Add(new Tetromino(1, 0, 0, 1, 0, 2, 1, 2, TetrominoTypeShape.Z));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 1, 1, 2, 1, TetrominoTypeShape.Z));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 0, 1, 0, 2, TetrominoTypeShape.J));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 1, 1, 1, 2, TetrominoTypeShape.J));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 0, 0, 1, TetrominoTypeShape.J));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 1, 1, 1, 2, TetrominoTypeShape.J));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 0, 2, 1, TetrominoTypeShape.L));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 1, 1, 1, 2, TetrominoTypeShape.L));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 0, 1, 0, 2, TetrominoTypeShape.L));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 1, 1, 1, 2, TetrominoTypeShape.L));

        ClasificateByTypeShape();
    }


    //----------------------------------------------------------------
    public Tetromino GetTetromino(int index)
    {
        return tetrominos[index];
    }

    public Tetromino GetTetromino(TetrominoTypeShape typeShape, int index)
    {
        return tetrominosByTypeShape[typeShape][index];
    }

    //----------------------------------------------------------------
    private void ClasificateByTypeShape()
    {
        tetrominosByTypeShape = new Dictionary<TetrominoTypeShape, List<Tetromino>>();

        tetrominosByTypeShape.Add(TetrominoTypeShape.I, new List<Tetromino>());
        tetrominosByTypeShape[TetrominoTypeShape.I].Add(tetrominos[0]);
        tetrominosByTypeShape[TetrominoTypeShape.I].Add(tetrominos[1]);

        tetrominosByTypeShape.Add(TetrominoTypeShape.O, new List<Tetromino>());
        tetrominosByTypeShape[TetrominoTypeShape.O].Add(tetrominos[2]);

        tetrominosByTypeShape.Add(TetrominoTypeShape.T, new List<Tetromino>());
        tetrominosByTypeShape[TetrominoTypeShape.T].Add(tetrominos[3]);
        tetrominosByTypeShape[TetrominoTypeShape.T].Add(tetrominos[4]);
        tetrominosByTypeShape[TetrominoTypeShape.T].Add(tetrominos[5]);
        tetrominosByTypeShape[TetrominoTypeShape.T].Add(tetrominos[6]);

        tetrominosByTypeShape.Add(TetrominoTypeShape.S, new List<Tetromino>());
        tetrominosByTypeShape[TetrominoTypeShape.S].Add(tetrominos[7]);
        tetrominosByTypeShape[TetrominoTypeShape.S].Add(tetrominos[8]);

        tetrominosByTypeShape.Add(TetrominoTypeShape.Z, new List<Tetromino>());
        tetrominosByTypeShape[TetrominoTypeShape.Z].Add(tetrominos[9]);
        tetrominosByTypeShape[TetrominoTypeShape.Z].Add(tetrominos[10]);

        tetrominosByTypeShape.Add(TetrominoTypeShape.J, new List<Tetromino>());
        tetrominosByTypeShape[TetrominoTypeShape.J].Add(tetrominos[11]);
        tetrominosByTypeShape[TetrominoTypeShape.J].Add(tetrominos[12]);
        tetrominosByTypeShape[TetrominoTypeShape.J].Add(tetrominos[13]);
        tetrominosByTypeShape[TetrominoTypeShape.J].Add(tetrominos[14]);

        tetrominosByTypeShape.Add(TetrominoTypeShape.L, new List<Tetromino>());
        tetrominosByTypeShape[TetrominoTypeShape.L].Add(tetrominos[15]);
        tetrominosByTypeShape[TetrominoTypeShape.L].Add(tetrominos[16]);
        tetrominosByTypeShape[TetrominoTypeShape.L].Add(tetrominos[17]);
        tetrominosByTypeShape[TetrominoTypeShape.L].Add(tetrominos[18]);
    }
}
