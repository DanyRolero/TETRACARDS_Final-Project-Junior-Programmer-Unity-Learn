using UnityEngine;

public abstract class CardPlacedEffectData : ScriptableObject
{
    public abstract PlacedBlocks GetPlacedPositions(Card card, BlocksGrid grid);
}
