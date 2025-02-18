using System.Collections.Generic;
using UnityEngine;

public class CyclicUniqueRandomIntCollection
{
    private List<int> _intCollection = new List<int>();
    private List<int> _copyIntCollection;

    //----------------------------------------------------------------
    public CyclicUniqueRandomIntCollection(int max, int min = 0)
    {
        for (int i = min; i <= max; i++)
        {
            _intCollection.Add(i);
        }
        _copyIntCollection = new List<int>(_intCollection);
    }

    //----------------------------------------------------------------
    private void ResetCopyCollection()
    {
        _copyIntCollection = new List<int>(_intCollection);
    }
    
    //----------------------------------------------------------------
    public int GetRandomInt()
    {
        if (_copyIntCollection.Count == 0)
        {
            ResetCopyCollection();
        }
        int randomIndex = Random.Range(0, _copyIntCollection.Count);
        int randomInt = _copyIntCollection[randomIndex];
        _copyIntCollection.RemoveAt(randomIndex);
        return randomInt;
    }
}
