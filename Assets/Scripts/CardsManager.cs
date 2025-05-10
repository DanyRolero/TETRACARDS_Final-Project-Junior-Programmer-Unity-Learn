using UnityEngine;
using UnityEngine.Video;

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
    public void DrawCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            DrawCard();
        }
    }

    //--------------------------------------------------------------------------------
    public void DrawCardsOnCompleteRows(int count)
    {
        float ratio = 1.8f;
        int cardsToDraw = Mathf.FloorToInt(count * ratio);
        Debug.Log(cardsToDraw);
        DrawCards(cardsToDraw);
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
