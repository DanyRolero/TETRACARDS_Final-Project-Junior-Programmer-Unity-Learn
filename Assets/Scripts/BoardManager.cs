using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private PreviewerBoard previewerBoard;
    [SerializeField] private BlocksGrid blocksGrid;
    [SerializeField] private MainBoardManager mainBoardManager;
    [SerializeField] private BoardSettings boardSettings;

    //----------------------------------------------------------------------------
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
        mainBoardManager.SetBoard(blocksGrid.GetTiles());
    }

}
