using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // Referencia al GameEvent que deseamos escuchar (asigna el asset desde el Inspector)
    public GameEventData gameEvent;
    // Respuesta que se invocará cuando se levante el evento, configurada desde el Inspector
    public UnityEvent response;

    private void OnEnable()
    {
        if (gameEvent != null)
            gameEvent.Event.AddListener(OnEventRaised);
    }

    private void OnDisable()
    {
        if (gameEvent != null)
            gameEvent.Event.RemoveListener(OnEventRaised);
    }

    // Este método se llama cuando se levanta el evento
    private void OnEventRaised()
    {
        // Ejecuta la respuesta asignada
        response.Invoke();
    }
}
