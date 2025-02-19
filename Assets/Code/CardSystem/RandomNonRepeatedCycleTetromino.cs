using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

public class RandomNonRepeatedCycleTetromino
{
    private TetrominoCollection tetrominoCollection = new TetrominoCollection();

    private CyclicUniqueRandomIntCollection tetrominoTypeShapes;

    private CyclicUniqueRandomIntCollection width1Tetrominos;
    private CyclicUniqueRandomIntCollection width2Tetrominos;
    private CyclicUniqueRandomIntCollection width3Tetrominos;
    private CyclicUniqueRandomIntCollection width4Tetrominos;

    private CyclicUniqueRandomIntCollection I_variants;
    private CyclicUniqueRandomIntCollection O_variants;
    private CyclicUniqueRandomIntCollection T_variants;
    private CyclicUniqueRandomIntCollection S_variants;
    private CyclicUniqueRandomIntCollection Z_variants;
    private CyclicUniqueRandomIntCollection J_variants;
    private CyclicUniqueRandomIntCollection L_variants;


    //----------------------------------------------------------------------------------------------------
    public RandomNonRepeatedCycleTetromino(int columnsInBoard)
    {   
        tetrominoTypeShapes = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape.Count);

        width1Tetrominos = new CyclicUniqueRandomIntCollection(columnsInBoard);
        width2Tetrominos = new CyclicUniqueRandomIntCollection(columnsInBoard - 1);
        width3Tetrominos = new CyclicUniqueRandomIntCollection(columnsInBoard - 2);
        width4Tetrominos = new CyclicUniqueRandomIntCollection(columnsInBoard - 3);

        I_variants = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape[TetrominoTypeShape.I].Count);
        O_variants = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape[TetrominoTypeShape.O].Count);
        T_variants = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape[TetrominoTypeShape.T].Count);
        S_variants = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape[TetrominoTypeShape.S].Count);
        Z_variants = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape[TetrominoTypeShape.Z].Count);
        J_variants = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape[TetrominoTypeShape.J].Count);
        L_variants = new CyclicUniqueRandomIntCollection(tetrominoCollection.tetrominosByTypeShape[TetrominoTypeShape.L].Count);
    }

    //----------------------------------------------------------------------------------------------------
    public Tetromino GetRandomTetromino()
    {
        int shapeIndex = GetRandomShapeIndex();
        int variantIndex = GetRandomVariantIndex(shapeIndex);
        Tetromino tetromino = tetrominoCollection.GetTetromino(shapeIndex, variantIndex);
        int position = GetRandomPosition(tetromino.Width);
        tetromino.Move(new Vector3Int(position, 0, 0));

        return tetromino;   
    }

    

    //----------------------------------------------------------------------------------------------------
    private int GetRandomShapeIndex()
    {
        return tetrominoTypeShapes.GetRandomInt();     
    }

    //----------------------------------------------------------------------------------------------------
    private int GetRandomVariantIndex(int shapeIndex)
    {
        switch (shapeIndex)
        {
            case 0:
                return I_variants.GetRandomInt();
            case 1:
                return O_variants.GetRandomInt();
            case 2:
                return T_variants.GetRandomInt();
            case 3:
                return S_variants.GetRandomInt();
            case 4:
                return Z_variants.GetRandomInt();
            case 5:
                return J_variants.GetRandomInt();
            case 6:
                return L_variants.GetRandomInt();
            default:
                return -1;
        }
    }

    //----------------------------------------------------------------------------------------------------
    private int GetRandomPosition(int width)
    {
        switch (width)
        {
            case 1:
                return width1Tetrominos.GetRandomInt();
            case 2:
                return width2Tetrominos.GetRandomInt();
            case 3:
                return width3Tetrominos.GetRandomInt();
            case 4:
                return width4Tetrominos.GetRandomInt();
            default:
                return -1;
        }
    }
}