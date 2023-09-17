using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptController : MonoBehaviour
{

    [SerializeField] TextUIElement interact1Prompt;
    [SerializeField] TextUIElement interact2Prompt;
    [SerializeField] TextUIElement interact3Prompt;

    [SerializeField] TextUIElement throwBallPrompt;

    TextUIElement[] interactPrompts;

    private void Start()
    {
        interactPrompts = new TextUIElement[] { interact1Prompt, interact2Prompt, interact3Prompt };
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void HideAll()
    {
        foreach (TextUIElement prompt in interactPrompts) prompt.Hide();

        throwBallPrompt.Hide();
    }

    public void SetInteractText(int keyNumber, string text)
    {
        CheckValidKeyNumber(keyNumber);

        interactPrompts[keyNumber - 1].SetText(text);

    }

    public void SetInteractVisible(int keyNumber, bool isVisible)
    {
        CheckValidKeyNumber(keyNumber);

        interactPrompts[keyNumber - 1].SetVisible(isVisible);
    }

    public void SetThrowBallVisible(bool isVisible)
    {
        throwBallPrompt.SetVisible(isVisible);
    }

    private void CheckValidKeyNumber(int keyNumber)
    {
        if (keyNumber < 1 || keyNumber > 3)
        {
            throw new Exception($"Key number {keyNumber} is not between 1 and 3.");
        }
    }
}

