using System.Collections.Generic;
using UnityEngine;
class RandomizerTetrominoCollection : TetrominoCollection, ITetrominoProvider
{
    private Dictionary<IdShape, SuffleBagIndexes> variantsByShapeBags;
    private SuffleBagIndexes shapesBag;
    public RandomizerTetrominoCollection()
    {
        InitializeVariantsByShapeBags();
        InitializeShapesBag();   
    }

    //----------------------------------------------------------------
    private void InitializeVariantsByShapeBags()
    {
        variantsByShapeBags = new Dictionary<IdShape, SuffleBagIndexes>();

        foreach (IdShape shape in tetrominosByShape.Keys)
        {
            variantsByShapeBags.Add(shape, new SuffleBagIndexes(tetrominosByShape[shape].Count));
        }

    }

    //----------------------------------------------------------------
    private void InitializeShapesBag()
    {
        shapesBag = new SuffleBagIndexes(tetrominosByShape.Count);
    }

    //----------------------------------------------------------------
    public Tetromino GetRandomTetromino()
    {
        int randomShapeIndex = shapesBag.GetRandomIndex();
        int randomVariantIndex = variantsByShapeBags[(IdShape)randomShapeIndex].GetRandomIndex();
        Debug.Log("Random shape index: " + randomShapeIndex + " Random variant index: " + randomVariantIndex);
        return tetrominosByShape[(IdShape)randomShapeIndex][randomVariantIndex];
    }

    //----------------------------------------------------------------
    public Tetromino GetTetromino()
    {
        return GetRandomTetromino();
    }
}