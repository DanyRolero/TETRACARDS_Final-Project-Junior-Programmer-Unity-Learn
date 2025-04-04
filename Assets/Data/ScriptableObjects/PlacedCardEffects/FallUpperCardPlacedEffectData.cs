using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------------------------------------------------------------------
[CreateAssetMenu(fileName = "FallUpperCardPlacedEffectData", menuName = "ScriptableObjects/CardPlacedEffect/FallUpperCardPlacedEffectData")]
public class FallUpperCardPlacedEffectData : CardPlacedEffectData
{
    public override PlacedBlocks ApplyEffect(Card card, BlocksGrid grid)
    {
        PolyminoData polymino = card.Polymino.Clone();
        polymino.Move(new Vector3Int(0, grid.Height - polymino.Height, 0));

        for(int y = grid.Height - 1; y >= 0 + polymino.Height; y--)
        {
            if(!grid.IsPolyminoCollision(polymino))
            {
                polymino.Move(Vector3Int.down);
            }
            else
            {
                polymino.Move(Vector3Int.up);
                break;
            }
        }

        PlacedBlocks placedBlocks = new PlacedBlocks(card.Blocks, polymino.Cells);
        

        return placedBlocks;
    }
}