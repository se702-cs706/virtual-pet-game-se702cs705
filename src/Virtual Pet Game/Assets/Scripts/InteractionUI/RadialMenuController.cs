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

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetInteractionIndex()
    {
        // TODO: get from menu implementation based on mouse angle
        return 0;
    }

    public void SetVisible(bool isVisible)
    {
        canvasGroup.alpha = isVisible ? 1 : 0;
        this.isVisible = isVisible;
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
