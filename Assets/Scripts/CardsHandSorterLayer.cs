using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsHandSorterLayer : MonoBehaviour
{
    [SerializeField] HandManager handManager;
    public void SortCardsInLayers()
    {
        int counter = 1;

        foreach(Card card in handManager.CardPool)
        {
            if(card.gameObject.activeSelf)
            {
                card.SortInLayer(counter);
                counter++;
            }
        }
    }
}
