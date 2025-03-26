using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SuffleBag<T>
{
    private List<T> _collection;
    private List<T> _copyCollection;

    //----------------------------------------------------------------
    public SuffleBag() 
    {
        _collection = new List<T>();
        _copyCollection = new List<T>();
    }

    //----------------------------------------------------------------
    public SuffleBag(List<T> collection)
    {
        _collection = new List<T>(collection);
        _copyCollection = new List<T>(_collection);
    }

    //----------------------------------------------------------------
    public void ResetCopyCollection()
    {
        _copyCollection = new List<T>(_collection);
    }

    //----------------------------------------------------------------
    public T GetRandomElement()
    {
        Console.WriteLine(_copyCollection.Count);
        if (_copyCollection.Count == 0)
        {
            ResetCopyCollection();
        }
        
        int randomIndex = UnityEngine.Random.Range(0, _copyCollection.Count);
        T randomElement = _copyCollection[randomIndex];
        _copyCollection.RemoveAt(randomIndex);

        return randomElement;
    }

    //----------------------------------------------------------------
    public void AddElementToBag(T element)
    {
        _collection.Add(element);
        _copyCollection.Add(element);
    }
}