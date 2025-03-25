using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    private CardsCollectionData cards;

    private Dictionary<int, Dictionary<IdShape, List<CardData>>> deck;
    private Dictionary<int, SuffleBag<IdShape>> randomIndexesByCells;

    private Dictionary<IdShape, SuffleBagIndexes> randomIndexesByShapes;
    private List<SuffleBagIndexes> randomIndexesByVariant;


    //--------------------------------------------------------------------------------
    private void Awake()
    {
        randomIndexesByShapes = new Dictionary<IdShape, SuffleBagIndexes>();

        foreach(int cellCount in deck.Keys)
        {
            if(!randomIndexesByShapes[cellCount].ContainsKey(cellCount))
            {
                randomIndexesByShapes.Add(cellCount, new SuffleBagIndexes());
            }

            foreach(IdShape shape in deck[cellCount].Keys)
            {
                randomIndexesByShapes
            }
        }
    }

    //--------------------------------------------------------------------------------
    private void InitializeDeck()
    {
        deck = new Dictionary<int, Dictionary<IdShape, List<CardData>>>();
        
        foreach(CardData card in cards.Collection)
        {
            if(!deck.ContainsKey(card.Polymino.CellsCount))
            {
                deck.Add(card.Polymino.CellsCount, new Dictionary<IdShape, List<CardData>>());
            }

            if(!deck[card.Polymino.CellsCount].ContainsKey(card.Polymino.IdShape))
            {
                deck[card.Polymino.CellsCount].Add(card.Polymino.IdShape, new List<CardData>());
            }

            deck[card.Polymino.CellsCount][card.Polymino.IdShape].Add(card);
        }
    }

    //--------------------------------------------------------------------------------
    private void InitializeRandomIndexesByCells()
    {
        randomIndexesByCells = new Dictionary<int, SuffleBag<IdShape>>();
        
        foreach(int cellCount in deck.Keys)
        {
            if(!randomIndexesByCells.ContainsKey(cellCount))
            {
                randomIndexesByCells.Add(cellCount, new SuffleBag<IdShape>());
            }

            foreach(IdShape shape in deck[cellCount].Keys)
            {
                randomIndexesByCells[cellCount].AddElementToBag(shape);
            }
        }
    }

    //--------------------------------------------------------------------------------
    private void InitializeRandomIndexesByShapes()
    {

    }
}