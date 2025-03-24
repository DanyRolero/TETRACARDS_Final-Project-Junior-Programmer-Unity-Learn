using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Eventos/GameEvent")]
public class GameEventData : ScriptableObject
{
    public UnityEvent Event;

    public void Raise()
    {
        // Verifica que el UnityEvent esté asignado y lo invoca
        if (Event != null)
            Event.Invoke();
    }
}
