using UnityEngine;
using UnityEngine.EventSystems;

public class MobileControls : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 MovementInput { get; private set; }

    [SerializeField] private float dragSensitivity = 100f;

    private Vector2 startPosition;
    private int activePointerId = -1;

    public void OnPointerDown(PointerEventData eventData)
    {
        activePointerId = eventData.pointerId;
        startPosition = eventData.position;
        UpdateInput(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        UpdateInput(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        MovementInput = Vector2.zero;
        activePointerId = -1;
    }

    private void UpdateInput(Vector2 position)
    {
        Vector2 delta = position - startPosition;
        MovementInput = Vector2.ClampMagnitude(
            delta / Mathf.Max(1f, dragSensitivity), 1f
        );
    }
}