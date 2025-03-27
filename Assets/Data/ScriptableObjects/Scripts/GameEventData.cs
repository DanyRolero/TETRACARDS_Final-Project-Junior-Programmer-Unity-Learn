using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventos/GameEvent")]
public class GameEventData : ScriptableObject
{
    public UnityEvent Event;

    public void Raise()
    {
        if (Event != null)
            Event.Invoke();
    }
}