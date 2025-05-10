using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private PreviewerBoard previewerBoard;
    [SerializeField] private BlocksGrid blocksGrid;
    [SerializeField] private MainBoardManager mainBoardManager;
    [SerializeField] private BoardSettings boardSettings;

    public GameEventData boardChangedEvent;
    public RowsCompleteEventData completeRowsEvent;

    //------------- ---------------------------------------------------------------
    void Awake()
    {
        blocksGrid.Initialize(boardSettings.gridSize);
    }


    //----------------------------------------------------------------------------
    public void PlacedBlockPreview(Card card)
    {
        PlacedBlocks placedBlocks = card.placedEffectData.ApplyEffect(card, blocksGrid);
        previewerBoard.SetTiles(placedBlocks);
    }

    //----------------------------------------------------------------------------
    public void CleanPreview()
    {
        previewerBoard.ClearBoard();
    }

    //----------------------------------------------------------------------------
    public void PlaceBlocks(Card card)
    {
        PlacedBlocks placedBlocks = card.placedEffectData.ApplyEffect(card, blocksGrid);
        blocksGrid.PlaceBlocks(placedBlocks);

        int completeRows = CountCompleteRows();

        if (completeRows > 0)
        {
            ClearCompleteRowsAndMoveRows();
            completeRowsEvent.Raise(completeRows);
        }

        mainBoardManager.SetBoard(blocksGrid.GetTiles());


  
    }

    //----------------------------------------------------------------------------
    private int CountCompleteRows()
    {
        int completeRows = 0;
        for (int i = 0; i < blocksGrid.Height; i++)
        {
            if (blocksGrid.IsRowComplete(i)) completeRows++;
        }
        return completeRows;
    }

    //----------------------------------------------------------------------------
    private void ClearCompleteRowsAndMoveRows()
    {
        for (int i = 0; i < blocksGrid.Height - 1; i++)
        {
            if (blocksGrid.IsRowComplete(i))
            {
                blocksGrid.ClearRow(i);
                for (int j = i + 1; j < blocksGrid.Height - 1; j++)
                {
                    blocksGrid.MoveRowDown(j);
                }
                i--;
            }
        }
    }

    //----------------------------------------------------------------------------
    private void InBoardChanged()
    {
        boardChangedEvent.Raise();
        Debug.Log("Board changed");
    }
}
