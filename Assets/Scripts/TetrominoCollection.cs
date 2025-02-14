using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoCollection
{
    List<Tetromino> tetrominos_I = new List<Tetromino>();
    List<Tetromino> tetrominos_O = new List<Tetromino>();
    List<Tetromino> tetrominos_T = new List<Tetromino>();
    List<Tetromino> tetrominos_S = new List<Tetromino>();
    List<Tetromino> tetrominos_Z = new List<Tetromino>();
    List<Tetromino> tetrominos_J = new List<Tetromino>();
    List<Tetromino> tetrominos_L = new List<Tetromino>();

    public TetrominoCollection()
    {
        //----------------------------------------------------------------
        // TETROMINOS I
        //----------------------------------------------------------------
        tetrominos_I.Add(new Tetromino());
        tetrominos_I[0].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_I[0].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_I[0].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos_I[0].SetUnit(3, new Vector3Int(3, 0, 0));

        tetrominos_I.Add(new Tetromino());
        tetrominos_I[1].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_I[1].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_I[1].SetUnit(2, new Vector3Int(0, 2, 0));
        tetrominos_I[1].SetUnit(3, new Vector3Int(0, 3, 0));


        //----------------------------------------------------------------
        // TETROMINOS O
        //----------------------------------------------------------------
        tetrominos_O.Add(new Tetromino());
        tetrominos_O[0].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_O[0].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_O[0].SetUnit(2, new Vector3Int(0, 1, 0));
        tetrominos_O[0].SetUnit(3, new Vector3Int(1, 1, 0));


        //----------------------------------------------------------------
        // TETROMINOS T
        //----------------------------------------------------------------
        tetrominos_T.Add(new Tetromino());
        tetrominos_T[0].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_T[0].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_T[0].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_T[0].SetUnit(3, new Vector3Int(0, 2, 0));

        tetrominos_T.Add(new Tetromino());
        tetrominos_T[1].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos_T[1].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_T[1].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_T[1].SetUnit(3, new Vector3Int(1, 2, 0));

        tetrominos_T.Add(new Tetromino());
        tetrominos_T[2].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_T[2].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_T[2].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos_T[2].SetUnit(3, new Vector3Int(1, 1, 0));

        tetrominos_T.Add(new Tetromino());
        tetrominos_T[3].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos_T[3].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_T[3].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_T[3].SetUnit(3, new Vector3Int(2, 1, 0));


        //----------------------------------------------------------------
        // TETROMINOS S
        //----------------------------------------------------------------
        tetrominos_S.Add(new Tetromino());
        tetrominos_S[0].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_S[0].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_S[0].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_S[0].SetUnit(3, new Vector3Int(1, 2, 0));

        tetrominos_S.Add(new Tetromino());
        tetrominos_S[1].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_S[1].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_S[1].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_S[1].SetUnit(3, new Vector3Int(2, 1, 0));


        //----------------------------------------------------------------
        // TETROMINOS Z
        //----------------------------------------------------------------
        tetrominos_Z.Add(new Tetromino());
        tetrominos_Z[0].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos_Z[0].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_Z[0].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_Z[0].SetUnit(3, new Vector3Int(0, 2, 0));

        tetrominos_Z.Add(new Tetromino());
        tetrominos_Z[1].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos_Z[1].SetUnit(1, new Vector3Int(2, 0, 0));
        tetrominos_Z[1].SetUnit(2, new Vector3Int(0, 1, 0));
        tetrominos_Z[1].SetUnit(3, new Vector3Int(1, 1, 0));


        //----------------------------------------------------------------
        // TETROMINOS J
        //----------------------------------------------------------------
        tetrominos_J.Add(new Tetromino());
        tetrominos_J[0].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_J[0].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_J[0].SetUnit(2, new Vector3Int(0, 1, 0));
        tetrominos_J[0].SetUnit(3, new Vector3Int(0, 2, 0));

        tetrominos_J.Add(new Tetromino());
        tetrominos_J[1].SetUnit(0, new Vector3Int(1, 0, 0));
        tetrominos_J[1].SetUnit(1, new Vector3Int(1, 1, 0));
        tetrominos_J[1].SetUnit(2, new Vector3Int(0, 2, 0));
        tetrominos_J[1].SetUnit(3, new Vector3Int(1, 2, 0));

        tetrominos_J.Add(new Tetromino());
        tetrominos_J[2].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_J[2].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_J[2].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos_J[2].SetUnit(3, new Vector3Int(2, 1, 0));

        tetrominos_J.Add(new Tetromino());
        tetrominos_J[3].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_J[3].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_J[3].SetUnit(2, new Vector3Int(2, 0, 0)); 
        tetrominos_J[3].SetUnit(3, new Vector3Int(2, 1, 0));

        

        //----------------------------------------------------------------
        // TETROMINOS J
        //----------------------------------------------------------------
        tetrominos_L.Add(new Tetromino());
        tetrominos_L[0].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_L[0].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_L[0].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_L[0].SetUnit(3, new Vector3Int(1, 2, 0));

        tetrominos_L.Add(new Tetromino());
        tetrominos_L[1].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_L[1].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_L[1].SetUnit(2, new Vector3Int(0, 2, 0));
        tetrominos_L[1].SetUnit(3, new Vector3Int(1, 2, 0));

        tetrominos_L.Add(new Tetromino());
        tetrominos_L[2].SetUnit(0, new Vector3Int(0, 0, 0));
        tetrominos_L[2].SetUnit(1, new Vector3Int(1, 0, 0));
        tetrominos_L[2].SetUnit(2, new Vector3Int(2, 0, 0));
        tetrominos_L[2].SetUnit(3, new Vector3Int(0, 1, 0));

        tetrominos_L.Add(new Tetromino());
        tetrominos_L[3].SetUnit(0, new Vector3Int(2, 0, 0));
        tetrominos_L[3].SetUnit(1, new Vector3Int(0, 1, 0));
        tetrominos_L[3].SetUnit(2, new Vector3Int(1, 1, 0));
        tetrominos_L[3].SetUnit(3, new Vector3Int(2, 1, 0));
        
    }


    //----------------------------------------------------------------
    public Tetromino GetTetromino(int indexShapeIndex, int index) {
        switch (indexShapeIndex) {
            case 0:
                return tetrominos_I[index];
            case 1:
                return tetrominos_O[index];
            case 2:
                return tetrominos_T[index];
            case 3:
                return tetrominos_S[index];
            case 4:
                return tetrominos_Z[index];
            case 5:
                return tetrominos_J[index];
            case 6:
                return tetrominos_L[index];
            default:
                return null;
        }
    }

}
