using UnityEngine;
using UnityEngine.EventSystems;

public class CameraTouchInput : MonoBehaviour, IDragHandler
{
    public Vector2 LookDelta { get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        LookDelta += eventData.delta;
    }

    public Vector2 GetLookDelta()
    {
        Vector2 delta = LookDelta;
        LookDelta = Vector2.zero;
        return delta;
    }
}