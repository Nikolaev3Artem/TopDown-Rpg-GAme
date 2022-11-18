using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform CameraTarget;

    private void Update()
    {
        Camera.transform.position = new Vector3(CameraTarget.transform.position.x, CameraTarget.transform.position.y,-10f);
    }
}
