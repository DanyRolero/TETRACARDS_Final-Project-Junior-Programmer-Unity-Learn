using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardPlacedEffectData cardPlacedEffectData;
    public CardData cardData;
    public BlocksGrid grid;
    public Card card;
    public PreviewerBoard previewerBoard;

    //--------------------------------------------------------------------------------
    private void Awake()
    {
        
        StartGame();
 
    }

    //--------------------------------------------------------------------------------
    private void StartGame()
    {
        Debug.Log("JUEGO INICIADO");
        grid.Initialize(new Vector2Int(4,15));
        card.Initialize(0,cardData);
        PlacedBlocks placedBlocks = cardPlacedEffectData.ApplyEffect(card, grid);
        previewerBoard.SetTiles(placedBlocks);


    }
}
