using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: Use singleton instead?
public class KeyBindings : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode KeyForward;
    public KeyCode KeyBackward;
    public KeyCode KeyLeft;
    public KeyCode KeyRight;
    public KeyCode KeyJump;

    [Header("Interaction")]
    public KeyCode KeyInteract1;
    public KeyCode KeyInteract2;
    public KeyCode KeyInteract3;

    [Header("Special")]
    public KeyCode KeyThrowBall;
    public KeyCode KeyShowVoiceCommands;
    public KeyCode KeyDogSit;
    public KeyCode KeyDogComeBoy;

    public KeyCode GetInteractKeyCode(InteractKey interactKey)
    {
        // FIXME: is there a better way to do this?
        return interactKey switch
        {
            InteractKey.Interact1 => KeyInteract1,
            InteractKey.Interact2 => KeyInteract2,
            InteractKey.Interact3 => KeyInteract3,
            _ => KeyCode.None,
        };
    }
}

public enum InteractKey
{
    Interact1, Interact2, Interact3
}
