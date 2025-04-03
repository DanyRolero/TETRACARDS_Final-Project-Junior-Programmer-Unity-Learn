using UnityEngine;

public abstract class CardPlacedEffectData : ScriptableObject
{
    public abstract Card GetPlacedPositions(Card card, BlocksGrid grid);
}
