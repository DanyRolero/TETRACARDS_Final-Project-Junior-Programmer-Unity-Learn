using UnityEngine;
using UnityEngine.Tilemaps;

public class CardData
{
    public readonly Polymino polymino;
    public readonly int xPosition;
    public readonly int idOrder;
    public readonly Tile tile;
    public readonly Sprite cardImage;

    public CardData(Polymino polymino, int xPosition, int idOrder, Tile tile, Sprite cardImage)
    {
        this.polymino = polymino;
        this.idOrder = idOrder;
        this.xPosition = xPosition;
        this.tile = tile;
        this.cardImage = cardImage;
    }
}
