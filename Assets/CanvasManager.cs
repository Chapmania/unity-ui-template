using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    MainMenu,
    PauseMenu,
    HUD,
    GameOverMenu
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController activeCanvas;

    protected override void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);
    }

    /// <summary> Switches the canvas to the desired canvas type </summary>
    public void SwitchCanvas(CanvasType canvasType)
    {
        if (activeCanvas != null)
        {
            activeCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == canvasType);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            activeCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("The desired canvas:" + desiredCanvas + " was not found.");
        }

    }
}
