using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IPointerMoveHandler
{
    public float dir;

    public float touchPosition;

    private void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = dir;
        }
    }

    void IPointerMoveHandler.OnPointerMove(PointerEventData eventData) { dir = Input.mousePosition.x - Screen.width / 2; }
}
