using UnityEngine.UI;
using UnityEngine;

public class ScrollContoller : MonoBehaviour
{
    public ScrollHandleController Scroller;
    public GameObject Content;

    private void Update()
    {
        // 1458.84 - max // 984.32 - min
        // 474 / p + 137 - верхний потолок; 474 / р

        if (Scroller.isReady)
        {
            float x = Scroller.transform.parent.position.x;
            float z = Scroller.transform.parent.position.z;
            float y = Input.mousePosition.y;

            float maxYposition = Scroller.transform.parent.position.y;
            float minYposition = Scroller.transform.parent.position.y - Scroller.transform.parent.GetComponent<RectTransform>().rect.height + 200f;

            //Debug.Log(Scroller.transform.localPosition.y);

            if (y <= maxYposition && y >= minYposition)
            {
                Scroller.transform.position = new Vector3(x, y, z);
            }
            if (y > maxYposition)
            {
                Scroller.transform.position = new Vector3(x, maxYposition, z);
            }

            if (y < minYposition)
            {
                Scroller.transform.position = new Vector3(x, minYposition, z);
            }

            Debug.Log(Content.transform.position.y);
            Debug.Log(Scroller.transform.position.y);

            float contentHeigth = Content.transform.GetComponent<RectTransform>().rect.height;
            float scrollerHeigth = maxYposition - minYposition;

            if (contentHeigth > scrollerHeigth)
            {
                Content.transform.localPosition = new Vector2(Content.transform.localPosition.x, 
                    - Scroller.transform.localPosition.y * (contentHeigth - scrollerHeigth) / (scrollerHeigth));
            }


        }


    }
}
