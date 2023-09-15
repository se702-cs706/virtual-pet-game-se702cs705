using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptController : MonoBehaviour
{

    [SerializeField] TextUIElement interactText;
    [SerializeField] TextUIElement selectInteractionText;
    [SerializeField] TextUIElement throwBallText;


    // Update is called once per frame
    void Update()
    {

    }

    public void HideAll()
    {
        interactText.Hide();
        selectInteractionText.Hide();
        throwBallText.Hide();
    }



    public void SetInteractVisible(bool isVisible)
    {
        interactText.SetVisible(isVisible);
    }

    public void SetSelectVisible(bool isVisible)
    {
        selectInteractionText.SetVisible(isVisible);
    }

    public void SetThrowBallVisible(bool isVisible)
    {
        throwBallText.SetVisible(isVisible);
    }
}

