using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A View component in the MVP pattern.
/// Used for interpreting inputs from keyboards.
/// </summary>
public class InputView : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode KeyForward;
    public KeyCode KeyBackward;
    public KeyCode KeyLeft;
    public KeyCode KeyRight;
    public KeyCode KeyJump;

    [Header("Interaction")] 
    public KeyCode KeyInteract;
    
    [Header("Presenter")]
    public CharacterPresenter characterPresenter;

    public void Update()
    {
        // key press action
        if(Input.GetKey(KeyForward) ||
            Input.GetKey(KeyBackward) || 
            Input.GetKey(KeyLeft) ||
            Input.GetKey(KeyRight))
        {
            characterPresenter.MovementKeyPressed(
                        Input.GetKey(KeyForward), 
                        Input.GetKey(KeyBackward), 
                        Input.GetKey(KeyLeft), 
                        Input.GetKey(KeyRight));
        }
        else
        {
            characterPresenter.MovementKeyReleased();
        }
        
        // jump key pressed
        if(Input.GetKeyDown(KeyJump))
        {
            characterPresenter.JumpKeyPressed();
        }
        
        // interact key pressed
        if (Input.GetKeyDown(KeyInteract))
        {
            // TODO make the interaction index dynamic
            characterPresenter.InteractKeyPressed(0);
        }
    }
}
