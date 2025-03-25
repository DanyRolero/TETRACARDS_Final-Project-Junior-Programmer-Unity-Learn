using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCardEvents : MonoBehaviour
{
    public delegate void CardHandDelegate(CardDataUpdater cardDataUpdater);
    public delegate void CardHandClearDelegate();
    public event CardHandDelegate OnHandCardMouseOver;
    public event CardHandDelegate OnHandCardClick;
    public event CardHandClearDelegate OnHandCardMouseExit;

    //--------------------------------------------------------------------------------
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            CardDataUpdater cardDataUpdater = hit.collider.gameObject.GetComponent<CardDataUpdater>();

            if (cardDataUpdater != null)
            {
                OnHandCardMouseOver?.Invoke(cardDataUpdater);

                if (Input.GetMouseButtonDown(0))
                {
                    OnHandCardClick?.Invoke(cardDataUpdater);
                }

            }
        }

        else OnHandCardMouseExit?.Invoke();
    }
}