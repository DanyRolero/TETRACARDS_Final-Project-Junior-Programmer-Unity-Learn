using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardMouseOverListener : MonoBehaviour
{
    [Header("Asignar el asset de tipo CardEventData")]
    public CardEventData cardMouseOverEvent;

    [Header("Respuesta a ejecutar cuando se pone el ratón sobre una carta")]
    public UnityEvent<Card> response;

    //----------------------------------------------------------------------------
    private void OnEnable()
    {
        if(cardMouseOverEvent != null)
        {
            cardMouseOverEvent.Event.AddListener(OnCardMouseOver);
        }
    }

    //----------------------------------------------------------------------------
    private void OnDisable()
    {
        if(cardMouseOverEvent != null)
        {
            cardMouseOverEvent.Event.RemoveListener(OnCardMouseOver);
        }
    }

    //----------------------------------------------------------------------------
    private void OnCardMouseOver(Card card)
    {
        response.Invoke(card);
    }
}
