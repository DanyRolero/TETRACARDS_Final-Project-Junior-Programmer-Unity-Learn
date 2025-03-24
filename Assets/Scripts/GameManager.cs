using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boardManager;
    public GameObject cardsManager;

    private BoardManager boardManagerScript;
    private CardHandManager cardsHandManagerScript;
    private MouseCardEvents mouseCardEventsScript;
    private GameSettings gameSettings;

    private int cardsPlayedInTurn;
    private int linesDestroyedInTurn;

    private Polymino currentPolymino;

    public GameEventData gameStartedEvent;




    /*  
        ----------------------------------------
        MECÁNICAS DEL JUEGO
        ----------------------------------------
        - Robo de cartas inicial 
    */
    //--------------------------------------------------------------------------------
    private void Awake()
    {
        Application.targetFrameRate = 30;
        StartGame();
        /*

        boardManagerScript = boardManager.GetComponent<BoardManager>();
        cardsHandManagerScript = cardsManager.GetComponent<CardHandManager>();
        mouseCardEventsScript = cardsManager.GetComponent<MouseCardEvents>();
        mouseCardEventsScript.OnHandCardMouseOver += CardHandMouseOverHandler;
        mouseCardEventsScript.OnHandCardMouseExit += CardHandMouseExitHandler;
        mouseCardEventsScript.OnHandCardClick += CardHandClickHandler;

        gameSettings = gameObject.GetComponent<GameSettings>();


        boardManagerScript.Initialize(gameSettings.gridSize);
        cardsHandManagerScript.Initialize(gameSettings.gridSize.x);
*/
    }

    //--------------------------------------------------------------------------------
    private void StartGame()
    {
        
        gameStartedEvent.Raise();
    }

    //--------------------------------------------------------------------------------
    private void IntialDraw()
    {
        cardsHandManagerScript.AddCard(gameSettings.amountInitialCards);
    }

    //--------------------------------------------------------------------------------
    private void CardHandMouseOverHandler(CardDataUpdater cardDataUpdater)
    {
        //currentPolymino = boardManagerScript.PreviewPolyminoInBoard(cardDataUpdater.polymino);
    }

    //--------------------------------------------------------------------------------
    private void CardHandClickHandler(CardDataUpdater cardDataUpdater)
    {
        Destroy(cardDataUpdater.gameObject);
        //boardManagerScript.PlacePolyminoInBoard(currentPolymino, cardDataUpdater.tile);
        boardManagerScript.Recount();
        int cardsDrawedForRows = (int)Math.Floor(gameSettings.drawRatioPerFullRows * boardManagerScript.Counters["Rows"]);
        cardsHandManagerScript.AddCard(cardsDrawedForRows);
        boardManagerScript.CleanFullRows();
    }

    //--------------------------------------------------------------------------------
    private void CardHandMouseExitHandler()
    {
        boardManagerScript.ClearGhostBoard();
    }
}
