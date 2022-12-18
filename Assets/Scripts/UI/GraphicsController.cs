using UnityEngine;
using UnityEngine.UI;

public class GraphicsController : MonoBehaviour
{
    public Vector2 ScreenSize;
    [SerializeField] Vector3[] scales;
    private float definition;

    private void Start()
    {
        ScreenSize = new Vector2(Screen.width, Screen.height);
        GetComponent<CanvasScaler>().referenceResolution = ScreenSize;
        definition = ScreenSize.x / ScreenSize.y;
        if (Mathf.Abs(definition - 0.5625f) < 0.01)
        {
            transform.GetChild(0).localScale = scales[0];
        }
        else if (Mathf.Abs(definition - 0.6f) < 0.01)
        {
            transform.GetChild(0).localScale = scales[1];
        }
        else if (Mathf.Abs(definition - 0.5f) < 0.01)
        {
            transform.GetChild(0).localScale = scales[2];
        }
        else if (Mathf.Abs(definition - 0.4864865f) < 0.01)
        {
            transform.GetChild(0).localScale = scales[3];
        }
    }
}
