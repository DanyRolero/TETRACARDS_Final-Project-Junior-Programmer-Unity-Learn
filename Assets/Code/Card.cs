using UnityEngine;
using UnityEngine.Tilemaps;

public class Card
{
    public Polymino Polymino {get; private set;}
    public int XPosition {get; private set;}
    public int IdOrder {get; private set;}
    public BlockData[] Blocks {get; private set;}
    public Sprite CardImage {get; private set;}

    public Card(int xPosition, CardData cardData)
    {
        
    }
}
