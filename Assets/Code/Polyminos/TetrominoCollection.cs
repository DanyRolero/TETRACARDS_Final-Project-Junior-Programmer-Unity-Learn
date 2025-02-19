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

        tetrominos.Add(new Tetromino(0, 0, 0, 1, 0, 2, 0, 3, TetrominoTypeShape.I));
        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 0, 3, 0, TetrominoTypeShape.I));

        tetrominos.Add(new Tetromino(0, 0, 1, 0,  0, 1, 1, 1, TetrominoTypeShape.O));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 0, 1, 1, TetrominoTypeShape.T));
        tetrominos.Add(new Tetromino(1, 0, 0, 1, 1, 1, 2, 1, TetrominoTypeShape.T));
        tetrominos.Add(new Tetromino(0, 0, 0, 1, 0, 2, 1, 1, TetrominoTypeShape.T));
        tetrominos.Add(new Tetromino(0, 1, 1, 0, 1, 1, 1, 2, TetrominoTypeShape.T));

        tetrominos.Add(new Tetromino(1, 0, 2, 0, 0, 1, 1, 1, TetrominoTypeShape.S));
        tetrominos.Add(new Tetromino(0, 0, 0, 1, 1, 1, 1, 2, TetrominoTypeShape.S));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 1, 1, 2, 1, TetrominoTypeShape.Z));
        tetrominos.Add(new Tetromino(1, 0, 0, 1, 1, 1, 0, 2, TetrominoTypeShape.Z));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 0, 2, 1, TetrominoTypeShape.J));
        tetrominos.Add(new Tetromino(0, 0, 0, 1, 1, 1, 2, 1, TetrominoTypeShape.J));
        tetrominos.Add(new Tetromino(1, 0, 1, 1, 1, 2, 0, 2, TetrominoTypeShape.J));
        tetrominos.Add(new Tetromino(0, 0, 0, 1, 0, 2, 1, 2, TetrominoTypeShape.J));

        tetrominos.Add(new Tetromino(0, 0, 1, 0, 2, 0, 0, 1, TetrominoTypeShape.L));
        tetrominos.Add(new Tetromino(0, 1, 1, 1, 2, 1, 2, 0, TetrominoTypeShape.L));
        tetrominos.Add(new Tetromino(0, 0, 0, 1, 0, 2, 1, 2, TetrominoTypeShape.L));
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

    public Tetromino GetTetromino(int typeShapeIndex, int index)
    {
        return tetrominosByTypeShape[(TetrominoTypeShape)typeShapeIndex][index];
    }

    //----------------------------------------------------------------
    private void ClasificateByTypeShape()
    {
        tetrominosByTypeShape = new Dictionary<TetrominoTypeShape, List<Tetromino>>();

        foreach (var tetromino in tetrominos)
        {
            if (!tetrominosByTypeShape.ContainsKey(tetromino.tetrominoTypeShape))
            {
                tetrominosByTypeShape[tetromino.tetrominoTypeShape] = new List<Tetromino>();
            }

            tetrominosByTypeShape[tetromino.tetrominoTypeShape].Add(tetromino);
        }
    }

}