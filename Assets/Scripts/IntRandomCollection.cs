using System.Collections.Generic;
using UnityEngine;

public class IntRandomCollection
{
    private List<int> _intCollection = new List<int>();
    private List<int> _copyIntCollection;

    //----------------------------------------------------------------
    public IntRandomCollection(int min, int max)
    {
        for (int i = min; i <= max; i++)
        {
            _intCollection.Add(i);
        }
        _copyIntCollection = new List<int>(_intCollection);
    }

    public IntRandomCollection(int max) {
        for (int i = 0; i < max; i++)
        {
            _intCollection.Add(i);
        }
        _copyIntCollection = new List<int>(_intCollection);
    }

    //----------------------------------------------------------------
    private void _ResetCopyCollection()
    {
        _copyIntCollection = new List<int>(_intCollection);
    }
    
    //----------------------------------------------------------------
    public int GetRandomInt()
    {
        if (_copyIntCollection.Count == 0)
        {
            _ResetCopyCollection();
        }
        int randomIndex = Random.Range(0, _copyIntCollection.Count);
        int randomInt = _copyIntCollection[randomIndex];
        _copyIntCollection.RemoveAt(randomIndex);
        return randomInt;
    }
}
