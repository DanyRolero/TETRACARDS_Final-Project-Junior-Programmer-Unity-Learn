using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    
    private static GameSettings _instance;
    
    // Board Settings
    public Vector2Int gridSize = new Vector2Int(4, 15); 
    
    // Cards Settings
    public int amountInitialCards = 8;
    public int amountTurnCards = 1;
    public int neededPlayedCardsForDraw = 4;
    public int neededDestroyedRowsForDraw = 4;
    public int amountCardsDrawedForPlayedCombo = 1;
    public int amountCardsDrawedForRowsCombo = 1;
    public float drawRatioPerFullRows = 1.8f;
    public int amountExtraCardsDrawedForMonocolorRow = 1;
    public int amountCardsDrawedForCleanTheBoard = 1;

    private GameSettings() { }

    //------------------------------------------------------------
    public static GameSettings GetInstance()
    {
        if(_instance == null) _instance = new GameSettings();
        return _instance;
    }

}
