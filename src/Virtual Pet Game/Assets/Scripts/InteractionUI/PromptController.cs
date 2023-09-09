using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptController : MonoBehaviour
{

    [SerializeField] TextUIElement interactText;
    [SerializeField] TextUIElement selectInteractionText;


    // Update is called once per frame
    void Update()
    {

    }

    public void HideAll()
    {
        interactText.Hide();
        selectInteractionText.Hide();
    }

    public void ShowInteract()
    {
        HideAll();
        interactText.Show();
    }

    public void ShowSelect()
    {
        HideAll();
        selectInteractionText.Show();
    }
}

