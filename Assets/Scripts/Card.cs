using UnityEngine;
using UnityEngine.Tilemaps;

public class Card : MonoBehaviour
{
    public Polymino Polymino {get; private set;}
    public int XPosition {get; private set;}
    public int IdOrder {get; private set;}
    public BlockData[] Blocks {get; private set;}
    public Sprite CardImage {get; private set;}

    public string cardName = "Evento mouse over de carta exitoso!";

    public void Initialize(int xPosition, CardData cardData)
    {
        
    }
}
