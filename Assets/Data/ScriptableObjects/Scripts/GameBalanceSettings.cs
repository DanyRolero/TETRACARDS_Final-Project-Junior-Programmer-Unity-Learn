using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameBalanceSettings", menuName = "GameBalanceSettings", order = 6)]
public class GameBalanceSettings : ScriptableObject
{

    [Header("Board Settings")]
    [SerializeField] public Vector2Int gridSize = new Vector2Int(4, 15); 
    
    [Header("Cards Settings")]
    [SerializeField] public int amountInitialCards = 8;
    [SerializeField] public int amountTurnCards = 1;
    [SerializeField] public int maxHandCards = 30;
    [SerializeField] public int neededPlayedCardsForDraw = 4;
    [SerializeField] public int neededDestroyedRowsForDraw = 4;
    [SerializeField] public int amountCardsDrawedForPlayedCombo = 1;
    [SerializeField] public int amountCardsDrawedForRowsCombo = 1;
    [SerializeField] public float drawRatioPerFullRows = 1.8f;
    [SerializeField] public int amountExtraCardsDrawedForMonocolorRow = 1;
    [SerializeField] public int amountCardsDrawedForCleanTheBoard = 1;
}
