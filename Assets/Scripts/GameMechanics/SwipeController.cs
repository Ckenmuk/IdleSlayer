using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SwipeController : MonoBehaviour//, IPointerMoveHandler
{
    public float dir;
    [SerializeField] private TMP_Text test;

    public float touchPosition;
    private Vector2 touchStart;
    private Vector2 touchEnd;
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
            touchStart = new Vector2(touch.position.x - Screen.width / 2.0f, touch.position.y);
            test.text = touchStart.x + "";
        }

        if (touch.phase == TouchPhase.Ended)
        {
            touchEnd = new Vector2(touch.position.x - Screen.width / 2.0f, touch.position.y);
            test.text = touchEnd.x + "";
        }

        dir = touchEnd.x - touchStart.x;
    }

    //void IPointerMoveHandler.OnPointerMove(PointerEventData eventData) { dir = Input.mousePosition.x - Screen.width / 2; }

}
