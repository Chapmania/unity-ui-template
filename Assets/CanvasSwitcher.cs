using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiderCanvasType;

    CanvasManager canvasManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
    }

    private void OnButtonClicked()
    {
        canvasManager.SwitchCanvas(desiderCanvasType);
    }
}
