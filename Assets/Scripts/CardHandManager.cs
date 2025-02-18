using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandManager : MonoBehaviour
{
    public GameObject cardPrefab;

    //--------------------------------------------------------------------------------
    public void AddCard()
    {
        Instantiate(cardPrefab, gameObject.transform);
    }

    //--------------------------------------------------------------------------------
    public void ClearHand()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

}
