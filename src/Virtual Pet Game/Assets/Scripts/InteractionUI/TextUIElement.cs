using System;
using TMPro;
using UnityEngine;

public class TextUIElement : MonoBehaviour, IInteractionUIElement
{
    public string text { get; private set; }
    GameObject _selfRef;

    private void Awake()
    {
        _selfRef = this.gameObject;

        TextMeshProUGUI tmp = _selfRef.GetComponent<TextMeshProUGUI>();

        if (tmp == null)
        {
            _selfRef.AddComponent<TextMeshProUGUI>();
        }
    }

    public void SetText(string text)
    {
        this.text = text;
        _selfRef.GetComponent<TextMeshProUGUI>().SetText(text);
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
