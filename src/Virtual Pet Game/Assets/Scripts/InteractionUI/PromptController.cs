using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptController : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField] TextUIElement interact1Prompt;
    [SerializeField] TextUIElement interact2Prompt;
    [SerializeField] TextUIElement interact3Prompt;

    [Header("Special")]
    [SerializeField] TextUIElement throwBallPrompt;

    [Header("Voice")]
    [SerializeField] GameObject voiceCommandsContainer;
    [SerializeField] TextUIElement sitPrompt;
    [SerializeField] TextUIElement comeBoyPrompt;

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

    public void SetSitVisible(bool isVisible)
    {
        sitPrompt.SetVisible(isVisible);
    }

    public void SetSitKey(KeyCode key)
    {
        sitPrompt.SetText($"'Sit' ({key})");
    }

    public void SetComeBoyVisible(bool isVisible)
    {
        comeBoyPrompt.SetVisible(isVisible);
    }

    public void SetComeBoyKey(KeyCode key)
    {
        comeBoyPrompt.SetText($"'Come Boy' ({key})");
    }

    public void SetVoiceCommandsVisible(bool isVisible)
    {
        voiceCommandsContainer.SetActive(isVisible);
        sitPrompt.SetVisible(isVisible);
        comeBoyPrompt.SetVisible(isVisible);
    }
}

