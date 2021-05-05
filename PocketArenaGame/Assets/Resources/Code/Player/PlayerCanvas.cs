using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCanvas : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject randomSpawnUnitUIGO;
    public int randomSpawnUnitsLeft;
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

    public void SetRandomSpawnIcon(string poolName)
    {
        var poolIcon = gameObject.GetComponent<PoolController>().poolDictionary[poolName].poolIcon;
        randomSpawnUnitUIGO.transform.GetComponent<Image>().sprite = poolIcon;
    }


}
