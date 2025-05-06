using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEventData : UnityEvent<int> { }

[CreateAssetMenu(menuName = "Eventos/Rows Complete Event")]
public class RowsCompleteEventData : ScriptableObject
{
    public IntEventData Event;
    public void Raise(int rowsComplete)
    {
        if (Event != null)
            Event.Invoke(rowsComplete);
    } 
}
