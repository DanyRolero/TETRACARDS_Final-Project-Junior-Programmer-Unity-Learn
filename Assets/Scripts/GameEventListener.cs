using UnityEngine;
using UnityEngine.Events;

// Se suscribiría / desuscribiría a los eventos.
// Se referencia al componentes que definen y lanzan el evento.
// Se referencia a los componentes que van a responder al evento.
// Se suscribe los métodos de los componentes que van a responder al evento.

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
