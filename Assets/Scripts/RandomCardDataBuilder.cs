using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class RandomCardDataBuilder : MonoBehaviour
{
    public ITetrominoProvider randomTetrominoProvider;
    public GameObject gridBoard;
    public Dictionary<int, SuffleBagIndexes> xPositionsByTetrominoWidth;
    public Sprite[] cardImages;
    public Tile[] tiles;
    public int columnsOnGridBoard;
    public Tetromino currentTetromino;
    public int tetrominoId;
    public int cardImageIndex;
    public int tileIndex;
    public int xPosition;
    public int idOrder;

 

    void Start()
    {
        randomTetrominoProvider = new RandomizerTetrominoCollection();
        InitializeXPositionByTetrominosWidth();
        GetNextRandomCardData();
    }

    private void InitializeXPositionByTetrominosWidth()
    {
        xPositionsByTetrominoWidth = new Dictionary<int, SuffleBagIndexes>();
        columnsOnGridBoard = (int)gridBoard.GetComponent<SpriteRenderer>().size.x;

        foreach (Tetromino tetromino in randomTetrominoProvider.GetTetrominos())
        {
            if (!xPositionsByTetrominoWidth.ContainsKey(tetromino.Width))
            {
                xPositionsByTetrominoWidth.Add(tetromino.Width, new SuffleBagIndexes(columnsOnGridBoard - tetromino.Width + 1));
            }
        }
    }

    //--------------------------------------------------------------------------------
    public CardData GetNextRandomCardData() 
    {
        currentTetromino = randomTetrominoProvider.GetTetromino().Clone();
        tetrominoId = currentTetromino.Id;
        cardImageIndex = currentTetromino.Id;
        tileIndex = (int)currentTetromino.IdShape;
        xPosition = xPositionsByTetrominoWidth[currentTetromino.Width].GetRandomIndex();
        currentTetromino.Move(new Vector3Int(xPosition, 0, 0));
        idOrder = currentTetromino.Width + xPosition * 10;

        return new CardData(currentTetromino, xPosition, idOrder, tiles[tileIndex], cardImages[cardImageIndex]);
    }
}