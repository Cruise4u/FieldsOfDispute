using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCanvas : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject randomSpawnUnitUIGO;
    public Canvas canvas;

    public void Init(PlayerTeam playerTeam)
    {
        if (playerTeam == PlayerTeam.TeamA)
        {
            playerCamera = GameObject.Find("TeamA_Camera").GetComponent<Camera>();
        }
        else
        {
            playerCamera = GameObject.Find("TeamB_Camera").GetComponent<Camera>();
        }
        SetCameraForCanvasRenderMode();
    }

    public void SetCameraForCanvasRenderMode()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = playerCamera;
    }

    public void SetRandomSpawnIcon()
    {
        var poolIcon = gameObject.GetComponent<PoolController>().currentPool.poolIcon;
        randomSpawnUnitUIGO.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = poolIcon;
    }

    public void SetRandomSpawnNumber(int number)
    {
        randomSpawnUnitUIGO.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "x"+ number.ToString();
    }

}
