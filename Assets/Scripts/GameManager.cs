using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boardManager;
    public GameObject cardsManager;

    private BoardManager boardManagerScript; 
    private CardHandManager cardsHandManagerScript;
    private GameSettings gameSettings;




    /*  
        ----------------------------------------
        MECÁNICAS DEL JUEGO
        ----------------------------------------
        - Robo de cartas inicial 
    */

    private void Awake() 
    {
        Application.targetFrameRate = 30;   

        boardManagerScript = boardManager.GetComponent<BoardManager>();
        cardsHandManagerScript = cardsManager.GetComponent<CardHandManager>();

        gameSettings = gameObject.GetComponent<GameSettings>();


        boardManagerScript.Initialize(gameSettings.gridSize);
        cardsHandManagerScript.Initialize(gameSettings.gridSize.x);
    }

    private void StartGame()
    {

    }
}
