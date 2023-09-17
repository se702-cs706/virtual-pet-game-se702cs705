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
    public CameraPresenter cameraPresenter;

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
        
        // interact key pressed
        if (Input.GetKeyDown(keyBindings.KeyInteract1))
        {
            if (characterPresenter.HasInteractions())
            {
                if (interactionUIPresenter.IsSingleAction())
                {
                    characterPresenter.InteractKeyPressed(0);
                }
            }
        }

        // throw ball key pressed
        if (Input.GetKeyDown(keyBindings.KeyThrowBall))
        {
            characterPresenter.ThrowBallKeyPressed();
        }
    }
}
