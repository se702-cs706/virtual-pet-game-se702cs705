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
    Dictionary<InteractKey, TextUIElement> interactPrompts;

    private void Start()
    {
        interactPrompts = new Dictionary<InteractKey, TextUIElement>
        {
            { InteractKey.Interact1, interact1Prompt },
            { InteractKey.Interact2, interact2Prompt },
            { InteractKey.Interact3, interact3Prompt }
        };
    }

    public void HideAll()
    {
        foreach (TextUIElement prompt in interactPrompts.Values) prompt.Hide();

        throwBallPrompt.Hide();
    }

    public void SetInteractText(InteractKey key, string text)
    {
        interactPrompts.TryGetValue(key, out TextUIElement prompt);

        prompt.SetText(text);
    }

    public void SetInteractVisible(InteractKey key, bool isVisible)
    {
        interactPrompts.TryGetValue(key, out TextUIElement prompt);

        prompt.SetVisible(isVisible);
    }

    public void SetThrowBallVisible(bool isVisible)
    {
        throwBallPrompt.SetVisible(isVisible);
    }

    public void SetThrowBallKey(KeyCode key)
    {
        throwBallPrompt.SetText($"Throw Ball ({key})");
    }
}

