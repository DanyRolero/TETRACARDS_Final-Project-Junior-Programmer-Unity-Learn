using UnityEngine;

public class CompleteRowsEventListener : MonoBehaviour
{
    [Header("Asignar el asset de tipo IntEventData")]
    public RowsCompleteEventData rowsCompleteEvent;
    public IntEventData onRowsCompleteResponse;

    private void OnEnable()
    {
        if (rowsCompleteEvent != null) rowsCompleteEvent.Event.AddListener(OnRowsComplete);
    }

    private void OnDisable()
    {
        if (rowsCompleteEvent != null) rowsCompleteEvent.Event.RemoveListener(OnRowsComplete);
    }

    private void OnRowsComplete(int rowsComplete)
    {
        onRowsCompleteResponse.Invoke(rowsComplete);
    }
}
