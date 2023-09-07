using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Presenter component in the MVP,
/// Takes care of state change in character and moving the character RB.
/// </summary>
public class CharacterPresenter : MonoBehaviour, IPresenter
{
    [Header("Model")]
    [SerializeField] PlayerController characterController;

    public void MovementKeyPressed(bool forward, bool back, bool left, bool right)
    {
        float vertialInput = 0;
        float hotizontalInput = 0;
        if (forward && !back)
        {
            vertialInput = 1;
        }
        else if(!forward && back)
        {
            vertialInput = -1;
        }

        if (right && !left)
        {
            hotizontalInput = 1;
        }
        else if (!right && left)
        {
            hotizontalInput = -1;
        }

        characterController.MovementInput(vertialInput, hotizontalInput);
    }

    public void MovementKeyReleased()
    {
        characterController.MovementInput(0,0);
    }

    public void JumpKeyPressed()
    {
        characterController.Jump();
    }

    public void onModelStateChanged()
    {
        var state = characterController.playerState;
        Debug.Log("CharacterPresenter: Player state changed to: " + state.ToString());
    }

    public void InteractKeyPressed(int i)
    {
        characterController.Interact(i);
    }
}
