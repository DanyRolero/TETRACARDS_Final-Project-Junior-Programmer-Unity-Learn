using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RandomFixedPolyminoCollection : FixedPolyminoCollection, IRandomPolyminoProvider
{
    public Dictionary<int, Dictionary<IdShape, List<Polymino>>> ClassificatedPolyminoes { get; private set; }
    private SuffleBagIndexes CellsCountBag;


    //----------------------------------------------------------------
    public RandomFixedPolyminoCollection()
    {
        
    }

    //----------------------------------------------------------------
    private void InitializeClassificatedPolyminoes()
    {
        ClassificatedPolyminoes = new Dictionary<int, Dictionary<IdShape, List<Polymino>>>();

        foreach (Polymino polymino in polyminoes)
        {
            if (!ClassificatedPolyminoes.ContainsKey(polymino.CellsCount))
            {
                ClassificatedPolyminoes.Add(polymino.CellsCount, new Dictionary<IdShape, List<Polymino>>());
            }

            if (!ClassificatedPolyminoes[polymino.CellsCount].ContainsKey(polymino.IdShape))
            {
                ClassificatedPolyminoes[polymino.CellsCount].Add(polymino.IdShape, new List<Polymino>());
            }

            ClassificatedPolyminoes[polymino.CellsCount][polymino.IdShape].Add(polymino);
        }
    }

    //----------------------------------------------------------------
    private void InitializeCellsCountBag()
    {
        CellsCountBag = new SuffleBagIndexes();
        
        foreach (int key in ClassificatedPolyminoes.Keys)
        {
            CellsCountBag.AddIndexToBag(key);
        }
    }

    //----------------------------------------------------------------
    public Polymino GetNextRandomPolymino()
    {

    }

    //----------------------------------------------------------------
    public Polymino[] GetPolyminoes()
    {

    }
}