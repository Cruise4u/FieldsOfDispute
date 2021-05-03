using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    public Canvas canvas;
  
    public void SetCameraForCanvasRenderMode(PlayerTeam playerTeam)
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        switch (playerTeam)
        {
            case PlayerTeam.TeamA:
                canvas.worldCamera = GameObject.Find("TeamA_Camera").GetComponent<Camera>();
                break;
            case PlayerTeam.TeamB:
                canvas.worldCamera = GameObject.Find("TeamB_Camera").GetComponent<Camera>();
                break;
        }


    }
}

