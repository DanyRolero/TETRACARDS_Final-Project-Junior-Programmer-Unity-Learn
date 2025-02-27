using UnityEngine;
using UnityEngine.Tilemaps;

public class CardData
{
    public readonly Tetromino tetromino;
    public readonly int xPosition;
    public readonly int idOrder;
    public readonly Tile tile;
    public readonly Sprite cardImage;

    public CardData(Tetromino tetromino, int xPosition, int idOrder, Tile tile, Sprite cardImage)
    {
        this.tetromino = tetromino;
        this.idOrder = idOrder;
        this.xPosition = xPosition;
        this.tile = tile;
        this.cardImage = cardImage;
    }
}
