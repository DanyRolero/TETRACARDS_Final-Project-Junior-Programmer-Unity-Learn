using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RandomFixedTetrominoCollection : FixedTetrominoCollection, IRandomPolyminoProvider
{
    private Dictionary<IdShape, List<Polymino>> polyminoesByShape;
    private Dictionary<IdShape, SuffleBagIndexes> variantsByShapeBags;
    private SuffleBagIndexes shapesBag;
    public RandomFixedTetrominoCollection() : base()
    {
        InitializePolyminoesByShape();
        InitializeVariantsByShapeBags();
        InitializeShapesBag();
    }

    //----------------------------------------------------------------
    private void InitializePolyminoesByShape()
    {
        polyminoesByShape = new Dictionary<IdShape, List<Polymino>>();

        foreach (Polymino polymino in polyminoes)
        {
            if (!polyminoesByShape.ContainsKey(polymino.IdShape))
            {
                polyminoesByShape.Add(polymino.IdShape, new List<Polymino>());
            }
            polyminoesByShape[polymino.IdShape].Add(polymino);
        }
    }

    //----------------------------------------------------------------
    private void InitializeVariantsByShapeBags()
    {
        variantsByShapeBags = new Dictionary<IdShape, SuffleBagIndexes>();

        foreach (IdShape shape in polyminoesByShape.Keys)
        {
            variantsByShapeBags.Add(shape, new SuffleBagIndexes(polyminoesByShape[shape].Count));
        }

    }

    //----------------------------------------------------------------
    private void InitializeShapesBag()
    {
        shapesBag = new SuffleBagIndexes(polyminoesByShape.Count);
    }

    //----------------------------------------------------------------
    public Polymino GetNextRandomPolymino()
    {
        int randomShapeIndex = shapesBag.GetRandomIndex();
        int randomVariantIndex = variantsByShapeBags.ElementAt(randomShapeIndex).Value.GetRandomIndex();
        return polyminoesByShape[variantsByShapeBags.ElementAt(randomShapeIndex).Key][randomVariantIndex];
    }

    //----------------------------------------------------------------
    public Polymino[] GetPolyminoes()
    {
        return polyminoes;
    }
}