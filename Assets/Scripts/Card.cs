using UnityEngine;

public class Card : MonoBehaviour
{
    public int XPosition {get; private set;}
    public PolyminoData Polymino {get; private set;}
    public int IdOrder {get; private set;}
    public BlockData[] Blocks {get; private set;}
    public Sprite CardImage {get; private set;}

    public void Initialize(int xPosition, CardData cardData)
    {
        XPosition = xPosition;
        Polymino = cardData.Polymino.Clone();
        IdOrder = xPosition * 10 + Polymino.Width;
        Blocks = cardData.Blocks;
        CardImage = cardData.Image;
    }   
}
