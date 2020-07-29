using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Inherit from this class to implement custom button functionality. </summary>
[RequireComponent(typeof(Button))]
public abstract class ButtonFunctionality : MonoBehaviour
{
    /// <summary> Reference to the button </summary>
    protected Button button;
    private bool functionalityEnabled = true;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    /// <summary> Run when the button is clicked. Add any button specific behaviour here. </summary>
    protected virtual void OnButtonClicked()
    {
        if (!functionalityEnabled) return;
        // Implement custom button functionality here...
    }
}
