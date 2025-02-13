using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoCollection
{
    List<Tetromino> tetrominos = new List<Tetromino>();
    List<Tetromino> tetrominos_I = new List<Tetromino>();
    List<Tetromino> tetrominos_O = new List<Tetromino>();
    List<Tetromino> tetrominos_T = new List<Tetromino>();
    List<Tetromino> tetrominos_S = new List<Tetromino>();
    List<Tetromino> tetrominos_Z = new List<Tetromino>();
    List<Tetromino> tetrominos_J = new List<Tetromino>();
    List<Tetromino> tetrominos_L = new List<Tetromino>();

    public TetrominoCollection()
    {
        // 1
        tetrominos.Add(new Tetromino(TetrominoTypeShape.I));
        tetrominos[0].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[0].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[0].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos[0].SetUnit(3, new Vector3Int(3, 0, 0));
        tetrominos_I.Add(tetrominos[0]);

        // 2

        tetrominos.Add(new Tetromino(TetrominoTypeShape.I));
        tetrominos[1].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[1].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[1].SetUnit(2, new Vector3Int(0, 2, 0));
        tetrominos[1].SetUnit(3, new Vector3Int(0, 3, 0));
        tetrominos_I.Add(tetrominos[1]);

        // 3
        tetrominos.Add(new Tetromino(TetrominoTypeShape.S));
        tetrominos[2].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[2].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[2].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[2].SetUnit(3, new Vector3Int(1, 2, 0));
        tetrominos_S.Add(tetrominos[2]);
        
        // 4
        tetrominos.Add(new Tetromino(TetrominoTypeShape.Z));
        tetrominos[3].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos[3].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[3].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[3].SetUnit(3, new Vector3Int(0, 2, 0));
        tetrominos_Z.Add(tetrominos[3]);

        // 5
        tetrominos.Add(new Tetromino(TetrominoTypeShape.O));
        tetrominos[4].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[4].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[4].SetUnit(2, new Vector3Int(0, 1, 0));
        tetrominos[4].SetUnit(3, new Vector3Int(1, 1, 0));
        tetrominos_O.Add(tetrominos[4]);

        // 6
        tetrominos.Add(new Tetromino(TetrominoTypeShape.T));
        tetrominos[5].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[5].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[5].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[5].SetUnit(3, new Vector3Int(0, 2, 0));
        tetrominos_T.Add(tetrominos[5]);

        // 7
        tetrominos.Add(new Tetromino(TetrominoTypeShape.T));
        tetrominos[6].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos[6].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[6].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[6].SetUnit(3, new Vector3Int(1, 2, 0));
        tetrominos_T.Add(tetrominos[6]);

        // 8
        tetrominos.Add(new Tetromino(TetrominoTypeShape.J));
        tetrominos[7].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[7].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[7].SetUnit(2, new Vector3Int(0, 1, 0));
        tetrominos[7].SetUnit(3, new Vector3Int(0, 2, 0));
        tetrominos_J.Add(tetrominos[7]);

        // 9
        tetrominos.Add(new Tetromino(TetrominoTypeShape.J));
        tetrominos[8].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos[8].SetUnit(1, new Vector3Int(1, 1, 0));
        tetrominos[8].SetUnit(2, new Vector3Int(0, 2, 0));
        tetrominos[8].SetUnit(3, new Vector3Int(1, 2, 0));
        tetrominos_J.Add(tetrominos[8]);

        // 10
        tetrominos.Add(new Tetromino(TetrominoTypeShape.L));
        tetrominos[9].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[9].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[9].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[9].SetUnit(3, new Vector3Int(1, 2, 0));
        tetrominos_L.Add(tetrominos[9]);

        // 11
        tetrominos.Add(new Tetromino(TetrominoTypeShape.L));
        tetrominos[10].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[10].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[10].SetUnit(2, new Vector3Int(0, 2, 0));
        tetrominos[10].SetUnit(3, new Vector3Int(1, 2, 0));
        tetrominos_L.Add(tetrominos[10]);

        // 12
        tetrominos.Add(new Tetromino(TetrominoTypeShape.L));
        tetrominos[11].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[11].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[11].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos[11].SetUnit(3, new Vector3Int(0, 1, 0));
        tetrominos_L.Add(tetrominos[11]);

        // 13
        tetrominos.Add(new Tetromino(TetrominoTypeShape.J));
        tetrominos[12].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[12].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[12].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos[12].SetUnit(3, new Vector3Int(2, 1, 0));
        tetrominos_J.Add(tetrominos[12]);

        // 14
        tetrominos.Add(new Tetromino(TetrominoTypeShape.L));
        tetrominos[13].SetUnit(0, new Vector3Int(2, 0, 0));
        tetrominos[13].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[13].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[13].SetUnit(3, new Vector3Int(2, 1, 0));
        tetrominos_L.Add(tetrominos[13]);

        // 15
        tetrominos.Add(new Tetromino(TetrominoTypeShape.J));
        tetrominos[14].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[14].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[14].SetUnit(2, new Vector3Int(2, 0, 0)); 
        tetrominos[14].SetUnit(3, new Vector3Int(2, 1, 0));
        tetrominos_J.Add(tetrominos[14]);

        // 16
        tetrominos.Add(new Tetromino(TetrominoTypeShape.S));
        tetrominos[15].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[15].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[15].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[15].SetUnit(3, new Vector3Int(2, 1, 0));
        tetrominos_S.Add(tetrominos[15]);

        // 17
        tetrominos.Add(new Tetromino(TetrominoTypeShape.Z));
        tetrominos[16].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos[16].SetUnit(1, new Vector3Int(2, 0, 0));
        tetrominos[16].SetUnit(2, new Vector3Int(0, 1, 0));
        tetrominos[16].SetUnit(3, new Vector3Int(1, 1, 0));
        tetrominos_Z.Add(tetrominos[16]);

        // 18
        tetrominos.Add(new Tetromino(TetrominoTypeShape.T));
        tetrominos[17].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos[17].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos[17].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos[17].SetUnit(3, new Vector3Int(1, 1, 0));
        tetrominos_T.Add(tetrominos[17]);

        // 19
        tetrominos.Add(new Tetromino(TetrominoTypeShape.T));
        tetrominos[18].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos[18].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos[18].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos[18].SetUnit(3, new Vector3Int(2, 1, 0));
        tetrominos_T.Add(tetrominos[18]);
    }
}
