using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The model in MVP controlling the radial menu state.
/// </summary>
public class RadialMenuController : MonoBehaviour, IInteractionUIElement
{

    private CanvasGroup canvasGroup;
    public bool isVisible { get; private set; }

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        Hide();
    }

    public int GetInteractionIndex()
    {
        // TODO: get from menu implementation based on mouse angle
        return 0;
    }

    public void SetVisible(bool isVisible)
    {
        this.isVisible = isVisible;
        canvasGroup.alpha = this.isVisible ? 1 : 0;
    }

    public void Hide()
    {
        SetVisible(false);
    }

    public void Show()
    {
        SetVisible(true);
    }
}
