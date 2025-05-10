using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CardEvent : UnityEvent<Card> { }

[CreateAssetMenu(menuName = "Eventos/Card Event")]
public class CardEventData : ScriptableObject
{
    public CardEvent Event;

    public void Raise(Card card)
    {
        if (Event != null)
            Event.Invoke(card);
    } 
}
