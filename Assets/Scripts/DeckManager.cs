using System.Collections.Generic;
using UnityEngine;


public class DeckManager : MonoBehaviour
{
    [SerializeField]
    private CardsCollectionData cards;

    private Dictionary<int, Dictionary<IdShape, List<CardData>>> deck;

    private SuffleBag<int> randomCellCount;
    private Dictionary<int, SuffleBag<IdShape>> randomIdShape;
    private Dictionary<IdShape, SuffleBagIndexes> randomShapeCardList;


    //--------------------------------------------------------------------------------
    private void Start()
    {
        InitializeDeck();
        InitializeRandomCellCount();
        InitializerandomIdShape();
        InitializerandomShapeCardList();
        GetRandomCardData();
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
    private void InitializeRandomCellCount()
    {
        randomCellCount = new SuffleBag<int>();

        foreach(int cellCount in deck.Keys)
        {
            randomCellCount.AddElementToBag(cellCount);
        }
    }
    
    //--------------------------------------------------------------------------------
    private void InitializerandomIdShape()
    {
        randomIdShape = new Dictionary<int, SuffleBag<IdShape>>();
        
        foreach(int cellCount in deck.Keys)
        {
            if(!randomIdShape.ContainsKey(cellCount))
            {
                randomIdShape.Add(cellCount, new SuffleBag<IdShape>());
            }

            foreach(IdShape shape in deck[cellCount].Keys)
            {
                randomIdShape[cellCount].AddElementToBag(shape);
            }
        }
    }

    //--------------------------------------------------------------------------------
    private void InitializerandomShapeCardList()
    {
        randomShapeCardList = new Dictionary<IdShape, SuffleBagIndexes>();

        foreach(int cellCount in deck.Keys)
        {
            foreach(IdShape shape in deck[cellCount].Keys)
            {
                randomShapeCardList.Add(shape, new SuffleBagIndexes(deck[cellCount][shape].Count));
            }
        }
    }

    //--------------------------------------------------------------------------------
    public CardData GetRandomCardData()
    {
        int randomCellCount = this.randomCellCount.GetRandomElement();
        IdShape randomIdShape = this.randomIdShape[randomCellCount].GetRandomElement();
        int randomIndex = this.randomShapeCardList[randomIdShape].GetRandomIndex();
        CardData randomCardData = deck[randomCellCount][randomIdShape][randomIndex];

        return randomCardData;
    }
}