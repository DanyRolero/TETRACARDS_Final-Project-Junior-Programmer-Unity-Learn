using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

public class RandomNonRepeatedCycleTetromino
{
    private TetrominoCollection tetrominoCollection = new TetrominoCollection();
    private SuffleBagIndexes tetrominoTypeShapes;
    private Dictionary<int, SuffleBagIndexes> randomPositionsByWidth;
    private Dictionary<TetrominoTypeShape, SuffleBagIndexes> tetrominosVariantsByTypeShape;


    //----------------------------------------------------------------------------------------------------
    public RandomNonRepeatedCycleTetromino(int totalPosiblePositions)
    {   
        tetrominoTypeShapes = new SuffleBagIndexes(tetrominoCollection.tetrominosByTypeShape.Count);

        randomPositionsByWidth = new Dictionary<int, SuffleBagIndexes>();
        randomPositionsByWidth.Add(1, new SuffleBagIndexes(totalPosiblePositions));
        randomPositionsByWidth.Add(2, new SuffleBagIndexes(totalPosiblePositions - 1));
        randomPositionsByWidth.Add(3, new SuffleBagIndexes(totalPosiblePositions - 2));
        randomPositionsByWidth.Add(4, new SuffleBagIndexes(totalPosiblePositions - 3));

        tetrominosVariantsByTypeShape = new Dictionary<TetrominoTypeShape, SuffleBagIndexes>();
        foreach (TetrominoTypeShape typeShape in tetrominoCollection.tetrominosByTypeShape.Keys)
        {
            tetrominosVariantsByTypeShape.Add(typeShape, new SuffleBagIndexes(tetrominoCollection.tetrominosByTypeShape[typeShape].Count));
        }

    }

    //----------------------------------------------------------------------------------------------------
    public Tetromino GetRandomTetromino()
    {
        int shapeIndex = GetRandomShapeIndex();
        int variantIndex = GetRandomVariantIndex(shapeIndex);
        int position = GetRandomPosition(tetrominoCollection.GetTetromino(TetrominoTypeShape.GetTetrominoTypeShape(shapeIndex), variantIndex).Width);

        return tetrominoCollection.GetTetromino(TetrominoTypeShape.GetTetrominoTypeShape(shapeIndex), variantIndex).Clone(position);
    }

    

    //----------------------------------------------------------------------------------------------------
    private int GetRandomShapeIndex()
    {
        return tetrominoTypeShapes.GetRandomIndex();     
    }

    //----------------------------------------------------------------------------------------------------
    private int GetRandomVariantIndex(int shapeIndex)
    {
        return tetrominosVariantsByTypeShape[(TetrominoTypeShape)shapeIndex].GetRandomIndex();
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