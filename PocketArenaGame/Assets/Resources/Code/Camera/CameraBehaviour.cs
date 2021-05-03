using System;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject cameraGO;
    public float panSpeed;
    public float zoomSpeedTouch;
    public float leftBound;
    public float rightBound;
    public float topBound;
    public float bottomBound;

    public float minZoom;
    public float maxZoom;

    private bool panActive;
    private Vector3 originPanPosition;
    private int panFingerId; // Touch mode only

    private bool zoomActive;
    private Vector2[] lastZoomPositions; // Touch mode only
    public void ClampToBounds(Transform transform)
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, leftBound, rightBound);
        pos.z = Mathf.Clamp(transform.position.z, topBound, bottomBound);

        transform.position = pos;
    }
    public void Zoom(Camera camera, float offset, float speed)
    {
        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - (offset * speed), minZoom, maxZoom);
    }
    public void HandleTouch(Camera camera, Transform transform)
    {
        switch (Input.touchCount)
        {

            case 1: // Panning
                zoomActive = false;
                // If the touch began, capture its position and its finger ID.
                // Otherwise, if the finger ID of the touch doesn't match, skip it.
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    originPanPosition = touch.position;
                    panFingerId = touch.fingerId;
                    panActive = true;
                }
                else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved)
                {
                    //PanCamera(camera, transform, touch.position);
                }
                break;

            case 2: // Zooming
                panActive = false;
                Vector2[] newPositions = new Vector2[] { Input.GetTouch(0).position, Input.GetTouch(1).position };
                if (!zoomActive)
                {
                    lastZoomPositions = newPositions;
                    zoomActive = true;
                }
                else
                {
                    // Zoom based on the distance between the new positions compared to the 
                    // distance between the previous positions.
                    float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                    float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                    float offset = newDistance - oldDistance;
                    Zoom(camera, offset, zoomSpeedTouch);
                    lastZoomPositions = newPositions;
                }
                break;
            default:
                panActive = false;
                zoomActive = false;
                break;
        }
    }
    public void HandleMouse(Camera camera,Transform transform)
    {
        // On mouse down, capture it's position.
        // Otherwise, if the mouse is still down, pan the camera.
        if (Input.GetMouseButtonDown(0))
        {
            originPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            //PanCamera(camera,transform,Input.mousePosition);
        }

        // Check for scrolling to zoom the camera
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Zoom(camera, scroll, zoomSpeedTouch);
    }
    public void SetPanOriginPoint(Camera camera,Vector3 position)
    {
        originPanPosition = position;
    }
    public void PanCameraAroundOriginPoint(Camera camera,Vector3 currentPosition)
    {
        Vector3 cameraOffset = camera.ScreenToViewportPoint(originPanPosition - currentPosition);
        Vector3 cameraDirection = new Vector3(cameraOffset.x * panSpeed, 0, cameraOffset.y * panSpeed);

        // Perform the movement
        camera.transform.Translate(cameraDirection, Space.World);

        // Ensure the camera remains within bounds.
        Vector3 cameraPosition = camera.transform.position;
        cameraPosition.x = Mathf.Clamp(transform.position.x, leftBound, rightBound);
        cameraPosition.z = Mathf.Clamp(transform.position.z, topBound, bottomBound);
        camera.transform.position = cameraPosition;

        // Cache the position
        originPanPosition = currentPosition;
    }
}