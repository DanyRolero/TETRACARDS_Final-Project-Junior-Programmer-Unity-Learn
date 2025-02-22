using System.Collections.Generic;
using UnityEngine;
class RandomizerTetrominoCollection
{
    private TetrominoCollection tetrominoCollection;
    private Dictionary<IdShape, SuffleBagIndexes> variantsByShapeBags;
    private SuffleBagIndexes shapesBag;
    public RandomizerTetrominoCollection(TetrominoCollection collection)
    {
        tetrominoCollection = collection;
        InitializeVariantsByShapeBags();
        InitializeShapesBag();
        
    }

    //----------------------------------------------------------------
    private void InitializeVariantsByShapeBags()
    {
        variantsByShapeBags = new Dictionary<IdShape, SuffleBagIndexes>();

        foreach (IdShape shape in tetrominoCollection.tetrominosByShape.Keys)
        {
            variantsByShapeBags.Add(shape, new SuffleBagIndexes(tetrominoCollection.tetrominosByShape[shape].Count));
        }

    }

    //----------------------------------------------------------------
    private void InitializeShapesBag()
    {
        shapesBag = new SuffleBagIndexes(tetrominoCollection.tetrominosByShape.Count);
    }

    //----------------------------------------------------------------
    public Tetromino GetRandomTetromino()
    {
        int randomShapeIndex = shapesBag.GetRandomIndex();
        int randomVariantIndex = variantsByShapeBags[(IdShape)randomShapeIndex].GetRandomIndex();
        Debug.Log("Random shape index: " + randomShapeIndex + " Random variant index: " + randomVariantIndex);
        return tetrominoCollection.tetrominosByShape[(IdShape)randomShapeIndex][randomVariantIndex];
    }

}