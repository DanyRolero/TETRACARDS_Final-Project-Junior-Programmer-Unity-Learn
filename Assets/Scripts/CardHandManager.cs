using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandManager : MonoBehaviour
{
    public GameObject cardPrefab;
    private RandomCardDataBuilder randomCardDataBuilder;

    //--------------------------------------------------------------------------------
    void Start()
    {
        randomCardDataBuilder = gameObject.GetComponent<RandomCardDataBuilder>();
    }

    //--------------------------------------------------------------------------------
    public void AddCard()
    {
        InstanciateRandomCard();
        ReorderHandCardsByIdOrder();
        ReorderInLayer();
    }

    //--------------------------------------------------------------------------------
    public void ClearHand()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    //--------------------------------------------------------------------------------
    public void ReorderHandCardsByIdOrder()
    {
        int childCount = gameObject.transform.childCount;
        Transform[] children = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            children[i] = gameObject.transform.GetChild(i);
        }

        // Ordenar los hijos por el atributo 'idOrder'
        System.Array.Sort(children, (Transform a, Transform b) =>
        {
            CardDataUpdater orderA = a.GetComponent<CardDataUpdater>();
            CardDataUpdater orderB = b.GetComponent<CardDataUpdater>();

            if (orderA != null && orderB != null)
            {
                return orderA.idOrder.CompareTo(orderB.idOrder);
            }
            else if (orderA != null)
            {
                return -1;
            }
            else if (orderB != null)
            {
                return 1;
            }
            return 0;
        });

        // Ajustar los índices de los hijos en la jerarquía
        for (int i = 0; i < childCount; i++)
        {
            children[i].SetSiblingIndex(i);
        }
    }

    //--------------------------------------------------------------------------------
    private void InstanciateRandomCard() {
        GameObject tetroCard = Instantiate(cardPrefab, gameObject.transform);
        CardDataUpdater cardDataUpdater = tetroCard.GetComponent<CardDataUpdater>();
        CardData cardData = randomCardDataBuilder.GetNextRandomCardData();
        cardDataUpdater.UpdateCardData(cardData);
    }

    private void ReorderInLayer()
    {
        int childCount = gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            CardDataUpdater cardDataUpdater = gameObject.transform.GetChild(i).GetComponent<CardDataUpdater>();
            cardDataUpdater.SetOrderInLayer(i + 1);
        }
        
    }
}
