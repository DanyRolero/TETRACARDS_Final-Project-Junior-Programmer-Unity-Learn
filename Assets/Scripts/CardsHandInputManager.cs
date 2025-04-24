using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsHandInputManager : MonoBehaviour
{
    private Camera mainCamera;

    public CardEventData onHandCardMouseOverEvent;
    public CardEventData onHandCardLeftClickEvent;
    public GameEventData onHandCardMouseExitEvent;

    private Vector2 mousePosition;
    private RaycastHit2D hit;
    
    private Card currentCard;
    private Card lastCard;
    private Card clickedCard;

    void Start()
    {
        mainCamera = Camera.main;
    }


    //--------------------------------------------------------------------------------
    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Si el puntero del ratón está sobre un collider
        if (hit.collider == null)
        {
            // Si el anterior frame estuvo sobre una carta y ahora no
            if (lastCard != null)
            {
                OnHandCardMouseExit();
                lastCard = null;
            }
            return;
        }

        // Si el puntero del ratón está sobre un collider y el collider no es una carta
        currentCard = hit.collider.gameObject.GetComponent<Card>();
        if (currentCard == null) return;

        // Si el puntero del ratón está sobre una carta y el anterior frame era una carta diferente
        if (currentCard != lastCard)
        {
            if (lastCard != null) OnHandCardMouseExit();
            lastCard = currentCard;
            OnHandCardMouseOver();
        }

        // Si el puntero del ratón está sobre una carta y se hace click
        if (Input.GetMouseButtonDown(0))
        {
            clickedCard = currentCard;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (clickedCard == currentCard)
            {
                OnHandCardLeftClick();
            }
            clickedCard = null;
        }
    }

    //--------------------------------------------------------------------------------
    private void OnHandCardMouseOver()
    {
        onHandCardMouseOverEvent.Raise(currentCard);
    }

    //--------------------------------------------------------------------------------
    private void OnHandCardLeftClick()
    {
        onHandCardLeftClickEvent.Raise(currentCard);
    }

    //--------------------------------------------------------------------------------
    private void OnHandCardMouseExit()
    {
        onHandCardMouseExitEvent.Raise();
    }

}
