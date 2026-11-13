using UnityEngine;
using UnityEngine.EventSystems;

public class MobileControls : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IDragHandler
{
    public Vector2 MovementInput { get; private set; }

    private Vector2 startPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - startPosition;
        MovementInput = Vector2.ClampMagnitude(delta / 100f, 1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MovementInput = Vector2.zero;
    }
}