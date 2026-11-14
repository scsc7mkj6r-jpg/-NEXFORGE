using UnityEngine;
using UnityEngine.EventSystems;

public class CameraTouchInput : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 LookDelta { get; private set; }

    private int activePointerId = -1;

    public void OnPointerDown(PointerEventData eventData)
    {
        activePointerId = eventData.pointerId;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        LookDelta += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        activePointerId = -1;
    }

    public Vector2 GetLookDelta()
    {
        Vector2 delta = LookDelta;
        LookDelta = Vector2.zero;
        return delta;
    }
}