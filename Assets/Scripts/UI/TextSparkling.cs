using UnityEngine;
using UnityEngine.UI;

public class TextSparkling : MonoBehaviour
{
    //public Color TextColor;
    //float dir = 1;
    public float speed;

    Color CurrentColor = Color.clear;


    void Update()
    {
        //float a = GetComponent<Text>().color.a;

        //if (a <= 0) {dir = 1;}
        //if (a >= 1) { dir = -1; }
        //a += dir * Time.deltaTime * speed;
        //GetComponent<Text>().color = new Color(0, 0, 0, a);

        if (GetComponent<Text>().color.a <= 0.1f) { CurrentColor = Color.black; }
        if (GetComponent<Text>().color.a >= 0.9f) { CurrentColor = Color.clear; }
        GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, CurrentColor, Time.deltaTime * speed);
    }
}
