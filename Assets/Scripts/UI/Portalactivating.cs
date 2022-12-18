using UnityEngine;
using UnityEngine.UI;

public class Portalactivating : MonoBehaviour
{
    private Color color = Color.clear;
    float dir = 1;
    public float speed;

    void Update()
    {
        float a = GetComponent<Image>().color.a;

        if (a <= .1) {dir = 1;}
        if (a >= .9) { dir = -1; }
        a += dir * Time.deltaTime * speed;
        GetComponent<Image>().color = new Color(a, a, 1, a);

    }
}
