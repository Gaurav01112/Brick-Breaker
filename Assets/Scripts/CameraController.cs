using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // Target aspect ratio (e.g., 16:9)

    void Start()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        Camera cam = GetComponent<Camera>();
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            // Ensure the camera is in portrait mode
            cam.orthographicSize = Screen.height / 2f / 100f; // Adjust the factor as needed
        }
        else
        {
            // Landscape mode
            if (scaleHeight < 1.0f)
            {
                cam.orthographicSize = cam.orthographicSize / scaleHeight;
            }
            Rect rect = cam.rect;
            if (scaleHeight < 1.0f) // Letterboxing in landscape mode
            {
                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;
            }
            else // Pillarboxing in portrait mode
            {
                float scaleWidth = 1.0f / scaleHeight;
                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;
            }
            cam.rect = rect;
        }
    }
}