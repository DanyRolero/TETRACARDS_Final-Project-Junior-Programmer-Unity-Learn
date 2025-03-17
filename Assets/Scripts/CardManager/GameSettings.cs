using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // Board Settings
    public Vector2Int gridSize = new Vector2Int(4, 15); 


    // Cards Settings
    public int amountInitialCards = 8;
    public int amountTurnCards = 1;
    public int neededPlayedCardsForDraw = 4;
    public int neededDestroyedRowsForDraw = 4;
    public int amountCardsDrawedForPlayedCombo = 1;
    public int amountCardsDrawedForRowsCombo = 1;
    public int amountCardsDrawedFor1Row = 1;
    public int amountCardsDrawedFor2Rows = 3;
    public int amountCardsDrawedFor3Rows = 5;
    public int amountCardsDrawedFor4Rows = 8;
    public int amountCardsDrawedFor5Rows = 10;
    public int amountExtraCardsDrawedForOneColorRow = 1;
    public int amountCardsDrawedForCleanTheBoard = 1;

}
