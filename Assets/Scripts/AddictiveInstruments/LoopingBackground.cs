using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    private float backgroundSpeed = .7f;
    [SerializeField] private Renderer backgroundRenderer;

    private void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0.0f, backgroundSpeed * Time.deltaTime);
    }
}
