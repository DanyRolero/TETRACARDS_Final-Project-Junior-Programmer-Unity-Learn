using System.Collections.Generic;
using UnityEngine;

public class OrderHandCars : MonoBehaviour
{
    [SerializeField] private HandManager handManager;
    private List<Card> activeCards;
    private List<Vector3> activePositions;

    //--------------------------------------------------------------------------------
    public void OrderHandCards()
    {
        if(handManager == null) Debug.LogError("handManager is null");
        if(handManager.CardPool == null) Debug.LogError("CardPool is null");

        GetActiveCardsPositions();
        SortCardsByIdOrder();
        SetOrderedPositions();
    }

    //--------------------------------------------------------------------------------
    private void GetActiveCardsPositions()
    {
        activeCards = new List<Card>();
        activePositions = new List<Vector3>();

        for (int i = 0; i < handManager.CardPool.Count; i++)
        {
            if (handManager.CardPool[i].gameObject.activeSelf)
            {
                activeCards.Add(handManager.CardPool[i]);
                activePositions.Add(handManager.CardPool[i].transform.position);
            }
        }
    }

    //--------------------------------------------------------------------------------
    private void SortCardsByIdOrder()
    {
        activeCards.Sort((Card a, Card b) =>
        {
            return a.IdOrder.CompareTo(b.IdOrder);
        });
    }

    //--------------------------------------------------------------------------------
    private void SetOrderedPositions()
    {
        for (int i = 0; i < activeCards.Count; i++)
        {
            activeCards[i].transform.position = activePositions[i];
            activeCards[i].SortInLayer(i + 1);
        }
    }
}
