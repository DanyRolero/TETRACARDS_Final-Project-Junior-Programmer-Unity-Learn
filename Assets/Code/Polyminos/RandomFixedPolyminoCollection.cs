using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RandomFixedPolyminoCollection : FixedPolyminoCollection, IRandomPolyminoProvider
{
    public Dictionary<int, Dictionary<IdShape, List<Polymino>>> ClassifiedPolyminoes { get; private set; }
    private SuffleBagIndexes cellsCountBag;
    private Dictionary<int, SuffleBagIndexes> shapesBags;
    private Dictionary<IdShape, SuffleBagIndexes> variantsBags;


    //----------------------------------------------------------------
    public RandomFixedPolyminoCollection()
    {
        InitializeClassifiedPolyminoes();
        InitializeCellsCountBag();
        InitializeShapesBags();
        InitializeVariantsBags();
    }

    //----------------------------------------------------------------
    // Short and classified polyminoes collection
    private void InitializeClassifiedPolyminoes()
    {
        ClassifiedPolyminoes = new Dictionary<int, Dictionary<IdShape, List<Polymino>>>();

        foreach (Polymino polymino in polyminoes)
        {
            if (!ClassifiedPolyminoes.ContainsKey(polymino.CellsCount))
            {
                ClassifiedPolyminoes.Add(polymino.CellsCount, new Dictionary<IdShape, List<Polymino>>());
            }

            if (!ClassifiedPolyminoes[polymino.CellsCount].ContainsKey(polymino.IdShape))
            {
                ClassifiedPolyminoes[polymino.CellsCount].Add(polymino.IdShape, new List<Polymino>());
            }

            ClassifiedPolyminoes[polymino.CellsCount][polymino.IdShape].Add(polymino);
        }
    }

    //----------------------------------------------------------------
    private void InitializeCellsCountBag()
    {
        cellsCountBag = new SuffleBagIndexes();

        foreach(int cellsCount in ClassifiedPolyminoes.Keys)
        {
            cellsCountBag.AddIndexToBag(cellsCount);
        }
    }

    //----------------------------------------------------------------
    private void InitializeShapesBags()
    {
        shapesBags = new Dictionary<int, SuffleBagIndexes>();

        foreach(int key in ClassifiedPolyminoes.Keys)
        {
            shapesBags.Add(key, new SuffleBagIndexes(ClassifiedPolyminoes[key].Count));
        }
    }

    //----------------------------------------------------------------
    private void InitializeVariantsBags()
    {
        variantsBags = new Dictionary<IdShape, SuffleBagIndexes>();

        foreach(int key in ClassifiedPolyminoes.Keys)
        {
            foreach(IdShape idShape in ClassifiedPolyminoes[key].Keys)
            {
                variantsBags.Add(idShape, new SuffleBagIndexes(ClassifiedPolyminoes[key][idShape].Count));
            }
        }
    }

    //----------------------------------------------------------------
    public Polymino GetNextRandomPolymino()
    {
        int randomCellsCount = cellsCountBag.GetRandomIndex();
        int randomIndexIdShape = shapesBags[randomCellsCount].GetRandomIndex();
        IdShape randomIdShape = ClassifiedPolyminoes[randomCellsCount].ElementAt(randomIndexIdShape).Key;
        int randomVariant = variantsBags[randomIdShape].GetRandomIndex();
        return ClassifiedPolyminoes[randomCellsCount][randomIdShape][randomVariant];
    }

    //----------------------------------------------------------------
    public Polymino[] GetPolyminoes()
    {
        return polyminoes;
    }
}