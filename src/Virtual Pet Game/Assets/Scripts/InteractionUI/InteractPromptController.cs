using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractPromptController : MonoBehaviour, IInteractionUIElement
{

    private GameObject _selfRef;


    // Start is called before the first frame update
    void Start()
    {
        _selfRef = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

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

