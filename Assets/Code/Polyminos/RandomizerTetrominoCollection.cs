using System.Collections.Generic;
using System.Linq;
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
        int randomVariantIndex = variantsByShapeBags.ElementAt(randomShapeIndex).Value.GetRandomIndex();
        return tetrominosByShape[variantsByShapeBags.ElementAt(randomShapeIndex).Key][randomVariantIndex];
    }

    //----------------------------------------------------------------
    public Tetromino GetTetromino()
    {
        return GetRandomTetromino();
    }

    //----------------------------------------------------------------
    public Tetromino[] GetTetrominos()
    {
        return this.tetrominos;
    }
}