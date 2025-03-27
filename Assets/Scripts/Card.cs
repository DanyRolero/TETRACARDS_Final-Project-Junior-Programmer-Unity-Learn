using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Text xPositionText;
    [SerializeField] private Canvas canvas;


    public Sprite CardImage {get; private set;}
    public int XPosition {get; private set;}
    public PolyminoData Polymino {get; private set;}
    public int IdOrder {get; private set;}
    public BlockData[] Blocks {get; private set;}

    public void Initialize(int xPosition, CardData cardData)
    {
        XPosition = xPosition;
        Polymino = cardData.Polymino.Clone();
        Polymino.Move(new Vector3Int(xPosition, 0, 0));
        IdOrder = xPosition * 10 + Polymino.Width;
        Blocks = cardData.Blocks;
        CardImage = cardData.Image;

        spriteRenderer.sprite = CardImage;
        xPositionText.text = (1 + XPosition).ToString();
    }

    public void SortInLayer(int order)
    {
        spriteRenderer.sortingOrder = order;
        canvas.sortingOrder = order;
    }   
}
