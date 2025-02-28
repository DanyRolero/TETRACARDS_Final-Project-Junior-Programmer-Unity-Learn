using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CardDataUpdater : MonoBehaviour
{
    public GameObject imageObject;
    public GameObject textObject;
    public GameObject canvas;
    public int xPosition;
    public Tile tile;
    public Tetromino tetromino;
    public int idOrder;

    //----------------------------------------------------------------------------------------------------
    public void UpdateCardData(CardData cardData)
    {
        tetromino = cardData.tetromino;
        xPosition = cardData.xPosition;
        idOrder = cardData.idOrder;
        tile = cardData.tile;
        imageObject.GetComponent<SpriteRenderer>().sprite = cardData.cardImage;
        textObject.GetComponent<Text>().text = xPosition.ToString();
    }

    public void SetOrderInLayer(int order) {
        imageObject.GetComponent<SpriteRenderer>().sortingOrder = order;
        canvas.GetComponent<Canvas>().sortingOrder = order;
    }
}
