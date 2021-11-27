using UnityEngine;

/// <summary>
/// This is a class that sets the UI based on the safe area of the phone
/// </summary>
public class SafeArea : MonoBehaviour
{
    RectTransform rect;
    Rect safeArea;
    Vector2 minAnchor, maxAnchor;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;

        minAnchor = safeArea.position;
        maxAnchor = safeArea.size + minAnchor;

        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        rect.anchorMin = minAnchor;
        rect.anchorMax = maxAnchor;
    }
}