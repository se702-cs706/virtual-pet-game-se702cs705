using System;
using UnityEngine;
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
}
