using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    private List<Card> cardPool;
    public List<Card> CardPool { get => cardPool; }

    public GameEventData handChangedEvent;
    //Crearía un delegado
    //Crearía un evento

    //--------------------------------------------------------------------------------
    public void AddCard(int xPolyminoPosition, CardData cardData)
    {
        for(int i = 0; i < cardPool.Count; i++)
        {
            if(!cardPool[i].gameObject.activeSelf)
            {
                cardPool[i].Initialize(xPolyminoPosition, cardData);
                ActiveCard(cardPool[i]);
                handChangedEvent.Raise();
                //Se emitiría el evento
                return;
            }
        }

    }

    //--------------------------------------------------------------------------------
    public void RemoveCard(Card card)
    {
        DesactiveCard(card);
        handChangedEvent.Raise();
    }

    //--------------------------------------------------------------------------------
    private void ActiveCard(Card card)
    {
        card.gameObject.SetActive(true);
    }

    //--------------------------------------------------------------------------------
    private void DesactiveCard(Card card)
    {
        card.gameObject.SetActive(false);
    }

    //--------------------------------------------------------------------------------
    public void Clear()
    {
        foreach(Card card in cardPool)
        {
            DesactiveCard(card);
        }
        
        handChangedEvent.Raise();
    }
}
