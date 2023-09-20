using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractionUIElement
{
    // Elements may handle visibility differently.
    public void SetVisible(bool isVisible);
    public void Show();
    public void Hide();
}
