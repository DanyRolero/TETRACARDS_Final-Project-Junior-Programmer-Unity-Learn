using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject frameCard;

    private void Start() 
    {
        SpriteRenderer sr =  frameCard.GetComponent<SpriteRenderer>();
        sr.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Debug.Log(sr.color);
    }
}
