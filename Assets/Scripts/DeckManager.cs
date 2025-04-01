using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private CardsCollectionData cards;
    [SerializeField] private GameBalanceSettings settings;

    private Dictionary<int, Dictionary<IdShape, List<CardData>>> deck;
    private SuffleBag<int> randomCellCount;
    private Dictionary<int, SuffleBag<IdShape>> randomIdShape;
    private Dictionary<IdShape, SuffleBagIndexes> randomShapeCardList;
    private Dictionary<int, SuffleBagIndexes> randomXPosition;

    //--------------------------------------------------------------------------------
    public void Initialize()
    {
        InitializeDeck();
        InitializeRandomCellCount();
        InitializeRandomIdShape();
        InitializeRandomShapeCardList();
        InitializeRandomXPosition();
    }

    //--------------------------------------------------------------------------------
    private void Awake()
    {
        Initialize();
        BlockData b = cards.Collection[0].Blocks[0];
        BlockData a = cards.Collection[1].Blocks[0];

        Debug.Log(b.Equals(a));
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

    //--------------------------------------------------------------------------------
    public int GetRandomXPosition(int width)
    {
        return randomXPosition[width].GetRandomIndex();
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
    private void InitializeRandomIdShape()
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
    private void InitializeRandomShapeCardList()
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
    private void InitializeRandomXPosition()
    {
        randomXPosition = new Dictionary<int, SuffleBagIndexes>();
        int possibleXPositions;

        foreach(CardData cardData in cards.Collection)
        {
            if(!randomXPosition.ContainsKey(cardData.Polymino.Width))
            {
                possibleXPositions = settings.gridSize.x - cardData.Polymino.Width + 1;
                randomXPosition.Add(cardData.Polymino.Width, new SuffleBagIndexes(possibleXPositions));
            }
        }
    }
}