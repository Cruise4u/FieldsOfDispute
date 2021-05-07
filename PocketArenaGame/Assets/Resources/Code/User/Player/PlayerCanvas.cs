using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayerCanvas : UserCanvas
{
    public override void WriteMessageForUser(string message)
    {
        messagePanelGO.GetComponent<TextMeshProUGUI>().text = message;
    }

    public void BlockUIInput()
    {

    }

    public void HideInputValidationButtons()
    {

    }
}
