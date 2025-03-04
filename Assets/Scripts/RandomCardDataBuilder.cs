using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomCardDataBuilder : MonoBehaviour
{
    public IRandomPolyminoProvider randomPolyminoProvider;
    public Dictionary<int, SuffleBagIndexes> xPositionsByPolyminoWidth;
    public Sprite[] cardImages;
    public Tile[] tiles;
    public Polymino currentPolymino;

    void Start()
    {
        randomPolyminoProvider  = new RandomFixedPolyminoCollection();
        Initialize();
    }

    private void Initialize()
    {
        int columnsOnGridBoard = (int)GameObject.Find("GridBoard").GetComponent<SpriteRenderer>().size.x;
        
        xPositionsByPolyminoWidth = new Dictionary<int, SuffleBagIndexes>();

        foreach (Polymino polymino in randomPolyminoProvider.GetPolyminoes())
        {
            if (!xPositionsByPolyminoWidth.ContainsKey(polymino.Width))
            {
                xPositionsByPolyminoWidth.Add(polymino.Width, new SuffleBagIndexes(columnsOnGridBoard - polymino.Width + 1));
            }
        }
    }

    //--------------------------------------------------------------------------------
    public CardData GetNextRandomCardData() 
    {
        Polymino currentPolymino = randomPolyminoProvider.GetNextRandomPolymino().Clone();
        int cardImageIndex = currentPolymino.Id;
        int tileIndex = (int)currentPolymino.IdShape;
        int xPosition = xPositionsByPolyminoWidth[currentPolymino.Width].GetRandomIndex();
        currentPolymino.Move(new Vector3Int(xPosition, 0, 0));
        int idOrder = currentPolymino.Width + xPosition * 10;

        return new CardData(currentPolymino, xPosition, idOrder, tiles[tileIndex], cardImages[cardImageIndex]);
    }
}