using System.Collections.Concurrent;
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


    //--------------------------------------------------------------------------------
    public void Initialize(int boardColumns)
    {
        randomPolyminoProvider  = new RandomFixedPolyminoCollection();
        
        int columnsOnGridBoard = boardColumns;
        
        xPositionsByPolyminoWidth = new Dictionary<int, SuffleBagIndexes>();
        
        SuffleBagIndexes currentBag;

        foreach (Polymino polymino in randomPolyminoProvider.GetPolyminoes())
        {
            if (!xPositionsByPolyminoWidth.ContainsKey(polymino.Width))
            {
                currentBag = new SuffleBagIndexes(columnsOnGridBoard - polymino.Width + 1);

                xPositionsByPolyminoWidth.Add(polymino.Width, currentBag);

                //Balanced edge cards positions
                currentBag.AddIndexToBag(0);

                
                if(polymino.Width == 1) currentBag.AddIndexToBag(columnsOnGridBoard - 1);
                if(polymino.Width == 2) currentBag.AddIndexToBag(columnsOnGridBoard - 2);
                if(polymino.Width == 3) currentBag.AddIndexToBag(columnsOnGridBoard - 3);
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

        // CORREGIR O REESTRUCTURAR SISTEMA DE POLYMINOS
        return new CardData(currentPolymino, xPosition, idOrder, tiles[tileIndex], cardImages[cardImageIndex]);
    }
}