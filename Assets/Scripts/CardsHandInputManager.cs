using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsHandInputManager : MonoBehaviour
{
    private Camera mainCamera;
    public CardEventData onHandCardMouseOverEvent;
    public CardEventData onHandCardLeftClickEvent;
    public CardEventData onHandCardMouseExitEvent;
    private Vector2 mousePosition;
    private Collider2D objectCollider;
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
        objectCollider = Physics2D.OverlapPoint(mousePosition);

        // Si el puntero del ratón está sobre un collider
        if (objectCollider == null)
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
        currentCard = objectCollider.gameObject.GetComponent<Card>();
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
        Debug.Log("Mouse over card event");
    }

    //--------------------------------------------------------------------------------
    private void OnHandCardLeftClick()
    {
        onHandCardLeftClickEvent.Raise(currentCard);
        Debug.Log("Mouse clicked card event");
    }

    //--------------------------------------------------------------------------------
    private void OnHandCardMouseExit()
    {
        onHandCardMouseExitEvent.Raise(lastCard);
        Debug.Log("Mouse exit card event");
    }

}
