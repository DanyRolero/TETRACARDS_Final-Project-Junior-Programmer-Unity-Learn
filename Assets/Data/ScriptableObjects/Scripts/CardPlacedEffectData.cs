using UnityEngine;

public abstract class CardPlacedEffectData : ScriptableObject
{
    public abstract PlacedBlocks ApplyEffect(Card card, BlocksGrid grid);
}