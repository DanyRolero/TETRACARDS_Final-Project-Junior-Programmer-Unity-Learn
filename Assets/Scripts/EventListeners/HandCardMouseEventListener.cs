using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandCardMouseEventListener : MonoBehaviour
{
    [Header("Asignar el asset de tipo EventData")]
    public CardEventData cardMouseOverEvent;
    public GameEventData cardMouseExitEvent;
    public CardEventData cardMouseClickEvent;

    [Header("Respuestas a ejecutar cuando se interactua con el ratón en las cartas de la mano")]
    public UnityEvent<Card> onCardMouseOverResponse;
    public UnityEvent onCardMouseExitRespone;
    public UnityEvent<Card> onCardMouseClickResponse;

    //----------------------------------------------------------------------------
    private void OnEnable()
    {
        if(cardMouseOverEvent != null) cardMouseOverEvent.Event.AddListener(OnCardMouseOver);
        if(cardMouseExitEvent != null) cardMouseExitEvent.Event.AddListener(OnCardMouseExit);
        if(cardMouseClickEvent != null) cardMouseClickEvent.Event.AddListener(OnCardMouseClick);
    }

    //----------------------------------------------------------------------------
    private void OnDisable()
    {
        if(cardMouseOverEvent != null) cardMouseOverEvent.Event.RemoveListener(OnCardMouseOver);
        if(cardMouseExitEvent != null) cardMouseExitEvent.Event.RemoveListener(OnCardMouseExit);
        if(cardMouseClickEvent != null) cardMouseClickEvent.Event.RemoveListener(OnCardMouseOver);   
    }

    //----------------------------------------------------------------------------
    private void OnCardMouseOver(Card card)
    {
        onCardMouseOverResponse.Invoke(card);
    }

    //----------------------------------------------------------------------------
    private void OnCardMouseExit()
    {
        onCardMouseExitRespone.Invoke();
    }

    //----------------------------------------------------------------------------
    private void OnCardMouseClick(Card card)
    {
        onCardMouseClickResponse.Invoke(card);
    }
}
