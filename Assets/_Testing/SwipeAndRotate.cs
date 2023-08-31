using UnityEngine;

public class SwipeAndRotate : MonoBehaviour
{
    bool canRotate = false;

    [Range(1f, 10f)]
    [SerializeField] private float intensity = 1;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float mouseDeltaX = Input.GetAxisRaw("Mouse X");
        float mouseDeltaY = Input.GetAxisRaw("Mouse Y");

        if (canRotate)
            transform.Rotate(0, -mouseDeltaX * intensity, 0);
    }

    private void OnMouseDown()
    {
        canRotate = true;
    }

    private void OnMouseUp()
    {
        canRotate = false;
    }
}
