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

        while(!grid.IsPolyminoCollision(polymino))
        {
            if(polymino.MinY == 0) break;
            polymino.Move(Vector3Int.down);
        }

        if(grid.IsPolyminoCollision(polymino)) polymino.Move(Vector3Int.up);

        PlacedBlocks placedBlocks = new PlacedBlocks(card.Blocks, polymino.Cells);        

        return placedBlocks;
    }
}