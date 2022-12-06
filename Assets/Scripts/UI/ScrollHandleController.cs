using UnityEngine.EventSystems;
using UnityEngine;

public class ScrollHandleController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isReady;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) { isReady = true; }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData) { isReady = false; }

}
