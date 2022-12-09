using UnityEngine.UI;
using UnityEngine;

public class AddsController : MonoBehaviour
{
    public GameObject Content;

    public float cellHeigth;
    public float spacing;

    public GameObject[] Nots = new GameObject[0];

    private void Update()
    {
        int count = 0;
        foreach(Transform child in Content.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                count++;
            }
        }
        float h = (count * cellHeigth) + (spacing * (count - 1));
        float w = Content.transform.parent.GetComponent<RectTransform>().sizeDelta.x;
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);
    }

    public void SpawnNewNote(string Name) 
    {
        Debug.Log(Name);
    }
}
