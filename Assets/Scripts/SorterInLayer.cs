using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorterInLayer : MonoBehaviour
{
    
    //--------------------------------------------------------------------------------
    // 
    private void ReorderInLayer()
    {
        int childCount = gameObject.transform.childCount;
        
        for (int i = 0; i < childCount; i++)
        {
            CardDataUpdater cardDataUpdater = gameObject.transform.GetChild(i).GetComponent<CardDataUpdater>();
            //cardDataUpdater.SetOrderInLayer(i + 1);
        }   
    }
}
