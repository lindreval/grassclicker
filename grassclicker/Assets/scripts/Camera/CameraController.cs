using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Camera cam;

    private float zoomSpeed = 0.01f;
    private float minZoom = 5f;
    private float maxZoom = 20f;

    private Vector3 lastTouchPos;
    private bool isDragging = false;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        cam = Camera.main;
    }

    void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    void Update()
    {
        HandleZoom();
        HandleDrag();
    }

    void HandleZoom()
    {
        // Zoom with mouse scroll (for Editor/Desktop)
        if (Mouse.current != null)
        {
            float scroll = Mouse.current.scroll.ReadValue().y;
            if (Mathf.Abs(scroll) > 0.01f)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
                return;
            }
        }

        // Zoom with touch pinch (for mobile devices)
        if (Touchscreen.current == null || Touchscreen.current.touches.Count < 2)
            return;

        var touch1 = Touchscreen.current.touches[0];
        var touch2 = Touchscreen.current.touches[1];

        if (touch1.isInProgress && touch2.isInProgress)
        {
            Vector2 t1Curr = touch1.position.ReadValue();
            Vector2 t2Curr = touch2.position.ReadValue();

            Vector2 t1Prev = t1Curr - touch1.delta.ReadValue();
            Vector2 t2Prev = t2Curr - touch2.delta.ReadValue();

            float prevDistance = Vector2.Distance(t1Prev, t2Prev);
            float currDistance = Vector2.Distance(t1Curr, t2Curr);
            float delta = currDistance - prevDistance;

            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - delta * zoomSpeed, minZoom, maxZoom);
        }
    }


    void HandleDrag()
    {
        float moveSpeed = 0.01f;

        // 🖱️ Mouse drag (Editor/Desktop)
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            cam.transform.Translate(-mouseDelta.x * moveSpeed, -mouseDelta.y * moveSpeed, 0);
            return;
        }

        // 📱 Touch drag (Mobile)
        if (Touchscreen.current == null || !Touchscreen.current.primaryTouch.press.isPressed)
            return;

        Vector2 delta = Touchscreen.current.primaryTouch.delta.ReadValue();
        cam.transform.Translate(-delta.x * moveSpeed, -delta.y * moveSpeed, 0);
    }

}
