using UnityEngine;
using UnityEngine.EventSystems;

public class MobileControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector2 MovementInput { get; private set; }

    private Vector2 startPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = eventData.position;
        UpdateInput(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateInput(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MovementInput = Vector2.zero;
    }

    private void UpdateInput(Vector2 position)
    {
        Vector2 delta = position - startPosition;
        MovementInput = Vector2.ClampMagnitude(delta / 100f, 1f);
    }
}