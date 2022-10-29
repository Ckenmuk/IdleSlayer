using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed = 1;
    [SerializeField] private Renderer backgroundRenderer;

    private void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0.0f, backgroundSpeed * Time.deltaTime);
    }
}
