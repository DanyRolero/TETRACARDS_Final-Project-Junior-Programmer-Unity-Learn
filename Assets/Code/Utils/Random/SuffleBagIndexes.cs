using System.Collections.Generic;
using UnityEngine;

public class SuffleBagIndexes
{
    private List<int> _intCollection = new List<int>();
    private List<int> _copyIntCollection;

    //----------------------------------------------------------------
    public SuffleBagIndexes() {}
    //----------------------------------------------------------------
    public SuffleBagIndexes(int length)
    {
        for (int i = 0; i < length; i++)
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
    public int GetRandomIndex()
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

    public void AddIndexToBag(int index)
    {
        _intCollection.Add(index);
        ResetCopyCollection();
    }
}