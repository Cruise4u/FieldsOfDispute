using UnityEngine;

public class TeamCamera : MonoBehaviour
{
    #region Camera Setup
    public Camera playerCamera;
    public GameObject viewTarget;
    public Vector3 cameraOffset;
    public float cameraPitch;
    public float cameraZoom;
    #endregion

    public void ChangeTargetFocused()
    {

    }

    public void FocusCameraOnTarget()
    {
        playerCamera.transform.position = viewTarget.transform.position - (cameraOffset * cameraZoom);
        playerCamera.transform.LookAt(viewTarget.transform.position );
    }

    public void LateUpdate()
    {
        FocusCameraOnTarget();
    }

}
