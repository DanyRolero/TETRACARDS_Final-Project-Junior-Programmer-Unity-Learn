using UnityEngine;

public abstract class BlockEffect : ScriptableObject
{
    //-----------------------------------------------------------------------------
    public override bool Equals(object other)
    {
        if (other is BlockEffect blockEffect)
        {
            return GetType() == blockEffect.GetType();
        }
        return false;
    }

    //-----------------------------------------------------------------------------
    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}