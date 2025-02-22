using UnityEngine.Tilemaps;
using UnityEngine;

public class CardData : MonoBehaviour
{
    Tetromino tetromino;
    int xPosition;
    int idOrder;
    Sprite image;
    Tile tile;

    //------------------------------------------------------------------------------------------------
    void Initialize(Tetromino tetromino, int xPosition, int idOrder, Sprite image, Tile tile)
    {
        this.tetromino = tetromino;
        this.xPosition = xPosition;
        this.idOrder = idOrder;
        this.image = image;
        this.tile = tile;
    }
}
