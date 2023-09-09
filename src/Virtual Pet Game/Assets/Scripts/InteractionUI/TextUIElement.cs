using System;
using TMPro;
using UnityEngine;

public class TextUIElement : MonoBehaviour, IInteractionUIElement
{
    GameObject _selfRef;

    private void Awake()
    {
        _selfRef = this.gameObject;
    }

    public void SetText(string text)
    {
        _selfRef.GetComponent<TextMeshPro>().SetText(text);
    }

    public void SetVisible(bool isVisible)
    {
        _selfRef.GetComponent<TextMeshProUGUI>().alpha = isVisible ? 1 : 0;
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
