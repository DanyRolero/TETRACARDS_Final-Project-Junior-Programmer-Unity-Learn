using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CardEventData cardEventData;
    private Vector2 mousePosition;
    private RaycastHit2D hit;
    private Card card;


    //--------------------------------------------------------------------------------
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider == null) return;

        card = hit.collider.gameObject.GetComponent<Card>();
        if (card == null) return;
        
        OnHandCardMouseOver();

        if (Input.GetMouseButtonDown(0))
        {
            // OnHandCardLeftClick();
        }
        

    }

    //--------------------------------------------------------------------------------
    private void OnHandCardMouseOver()
    {
        if (card != null) cardEventData.Raise(card);
    }

    //--------------------------------------------------------------------------------
}
