using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    public Camera playerCamera;
    public Canvas canvas;
  
    public void Init(PlayerTeam playerTeam)
    {
        if(playerTeam == PlayerTeam.TeamA)
        {
            playerCamera = GameObject.Find("TeamA_Camera").GetComponent<Camera>();
        }
        else
        {
            playerCamera = GameObject.Find("TeamB_Camera").GetComponent<Camera>();
        }
    }

    public void SetCameraForCanvasRenderMode()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = playerCamera;
    }
}

