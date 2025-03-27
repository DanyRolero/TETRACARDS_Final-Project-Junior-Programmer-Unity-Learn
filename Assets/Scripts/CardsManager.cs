using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private HandManager handManager;

    //--------------------------------------------------------------------------------
    public void DrawCard()
    {
        CardData cardData = deckManager.GetRandomCardData();
        int xPolyminoPosition = deckManager.GetRandomXPosition(cardData.Polymino.Width);
        handManager.AddCard(xPolyminoPosition, cardData);
        // Se levanta el evento de cartaRobada
    }

    //--------------------------------------------------------------------------------
    public void PlayCard(Card card)
    {
        handManager.RemoveCard(card);
        // Se levanta el evento de cartaJugada
    }

    //--------------------------------------------------------------------------------
    public void ClearHand()
    {
        handManager.Clear();
    }
}
