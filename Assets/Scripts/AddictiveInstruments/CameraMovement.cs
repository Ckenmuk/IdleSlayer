using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;

    private void Update()
    {
        transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
    }
}
