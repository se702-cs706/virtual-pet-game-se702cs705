using System;
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
    private List<RadialMenuSector> sectors;

    Vector2 cursorPos;
    float angle;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        sectors = new List<RadialMenuSector>();
    }

    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        // TODO: render sectors depending on mouse angle
        if (isVisible)
        {
            cursorPos.x = Input.mousePosition.x - (Screen.width / 2f);
            cursorPos.y = Input.mousePosition.y - (Screen.height / 2f);
            cursorPos.Normalize();

            if (cursorPos != Vector2.zero)
            {
                angle = Mathf.Atan2(cursorPos.y, -cursorPos.x);

                if (angle < 0)
                {
                    // Convert to angle between 0 and 2 PI
                    angle = 2 * Mathf.PI + angle;
                }
            }
        }
    }

    public int GetInteractionIndex()
    {
        foreach (RadialMenuSector sector in sectors)
        {
            if (sector.IsTargeted(angle)) return sector.index;
        }
        throw new Exception("No sectors selected. Check if mouse position is being updated.");
    }

    public void SetVisible(bool isVisible)
    {
        this.isVisible = isVisible;
        canvasGroup.alpha = this.isVisible ? 1 : 0;

        foreach (RadialMenuSector sector in sectors)
        {
            sector.SetVisible(isVisible);
        }
    }

    public void Hide()
    {
        SetVisible(false);
    }

    public void Show()
    {
        SetVisible(true);
    }

    public void AddSector(RadialMenuSector sector)
    {
        sectors.Add(sector);

        // Add sector as child of this 
        sector.gameObject.transform.SetParent(gameObject.transform);
    }

    public void ClearSectors()
    {
        foreach (RadialMenuSector sector in sectors)
        {
            Destroy(sector.gameObject);
        }

        sectors.Clear();
    }
  
}
