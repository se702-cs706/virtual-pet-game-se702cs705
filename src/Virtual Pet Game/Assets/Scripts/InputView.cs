using UnityEngine;

/// <summary>
/// A View component in the MVP pattern.
/// Used for interpreting inputs from keyboards.
/// </summary>
public class InputView : MonoBehaviour
{
    public KeyBindings keyBindings;

    [Header("Presenters")]
    public CharacterPresenter characterPresenter;
    public InteractionUIPresenter interactionUIPresenter;

    public void Update()
    {
        // key press action
        if(Input.GetKey(keyBindings.KeyForward) ||
            Input.GetKey(keyBindings.KeyBackward) || 
            Input.GetKey(keyBindings.KeyLeft) ||
            Input.GetKey(keyBindings.KeyRight))
        {
            characterPresenter.MovementKeyPressed(
                        Input.GetKey(keyBindings.KeyForward), 
                        Input.GetKey(keyBindings.KeyBackward), 
                        Input.GetKey(keyBindings.KeyLeft), 
                        Input.GetKey(keyBindings.KeyRight));
        }
        else
        {
            characterPresenter.MovementKeyReleased();
        }
        
        // jump key pressed
        if(Input.GetKeyDown(keyBindings.KeyJump))
        {
            characterPresenter.JumpKeyPressed();
        }

        if (Input.GetKeyDown(keyBindings.KeyCloseMenu))
        {
            if (interactionUIPresenter.IsMenuOpen())
            {
                ExitMenuMode();
            }
        }
        
        // interact key pressed
        if (Input.GetKeyDown(keyBindings.KeyInteract))
        {
            if (characterPresenter.HasInteractions())
            {
                if (interactionUIPresenter.IsSingleAction())
                {
                    characterPresenter.InteractKeyPressed(0);
                }
                else
                {
                    if (interactionUIPresenter.IsMenuOpen())
                    {
                        // Allow click to select interaction index
                        int index = interactionUIPresenter.GetInteractionIndex();
                        characterPresenter.InteractKeyPressed(index);
                    }
                    else
                    {
                        EnterMenuMode();
                    }
                }
            }
        }

        // throw ball key pressed
        if (Input.GetKeyDown(keyBindings.KeyThrowBall))
        {
            characterPresenter.ThrowBallKeyPressed();
        }
    }

    private void EnterMenuMode()
    {
        interactionUIPresenter.OpenMenu();
        // TODO: Lock camera
        Cursor.visible = true;
    }

    private void ExitMenuMode()
    {
        interactionUIPresenter.CloseMenu();
        // TODO: Unlock camera
        Cursor.visible = false;
    }
}
