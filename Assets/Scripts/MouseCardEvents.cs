using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCardEvents : MonoBehaviour
{
    public GameObject board;
    private BoardManager boardManager;
    private Tetromino currentTetromino;
    void Start()
    {
        boardManager = board.GetComponent<BoardManager>();
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        
        if(hit.collider != null)
        {
            CardDataUpdater cardDataUpdater = hit.collider.gameObject.GetComponent<CardDataUpdater>();
            
            if (cardDataUpdater != null)
            {
                currentTetromino = boardManager.PreviewTetrominoInBoard(cardDataUpdater.tetromino);

                if (Input.GetMouseButtonDown(0))
                {
                    boardManager.PlaceTetrominoInBoard(currentTetromino, cardDataUpdater.tile);
                }
            }   
        }

        else 
        {
            boardManager.ClearGhostBoard();
        }
    }
}
