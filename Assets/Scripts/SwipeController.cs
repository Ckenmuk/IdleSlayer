using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IPointerMoveHandler
{
    public float dir;

    public float touchPosition;
    private Vector3 touchStart;
    private Vector3 touchEnd;
    private Touch touch;

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition++;
        }

        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            touchEnd = touch.position;
        }

        if (touchStart.x > touchEnd.x)
        {
            touchPosition = -1;
        }
        if (touchStart.x < touchEnd.x)
        {
            touchPosition = 1;
        }
    }

    void IPointerMoveHandler.OnPointerMove(PointerEventData eventData) { dir = Input.mousePosition.x - Screen.width / 2; }

}
